using CapCutTool.Core;
using CapCutTool.Core.Model;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;
using static CapCutTool.Core.Model.Materials.MaterialAnimation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapCutTool.Service
{
    public interface IDraftService
    {
        Task<bool> GetContext(string projectName);
        Task<bool> InsertAnimation(List<MaterialAnimation> animations, int randomNum, float timeAnimation);
        Task<bool> InsertEffect(List<VideoEffect> videoEffects, int timeEffect = 100, bool isInsertToImageAndVideo = false);
        Task<bool> InsertTransition(List<Transition> transitions, double time = 1);

    }
    public class DraftService : IDraftService
    {
        const string projectName = "clip_test";
        const string projectFilePath = "C:\\Users\\ADMIN\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
        public Context Ctx { get; private set; }
        public Project Proj { get; private set; }
        public DraftService()
        {

        }

        public async Task<bool> InsertAnimation(List<MaterialAnimation> animations, int step = 0, float timeAnimation = 0)
        {
            // Lấy video animation
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == TrackType.Video)?.Segments;
            if (videoSegment != null && videoSegment?.Count > 0)
            {
                // 1. Clear list animation, Clear animation ID in video
                var animationNeedDelete = new List<MaterialAnimation>(animations);
                if (Proj.Materials.MaterialAnimations.Count > 0)
                {
                    animationNeedDelete.AddRange(Proj.Materials.MaterialAnimations);
                    Proj.Materials.MaterialAnimations.Clear();
                }

                foreach (var video in videoSegment)
                {
                    foreach (var animation in animationNeedDelete)
                    {
                        if (video.ExtraMaterialRefs.Contains(animation.Id))
                        {
                            video.ExtraMaterialRefs.Remove(animation.Id);
                        }

                    }
                }

                // 2. Thêm các animation vào material
                // Update thời gian cho từng animation
                if (timeAnimation > 0)
                {
                    animations.ForEach(animation =>
                    {
                        if (animation.Animations.Count > 0)
                        {
                            animation.Animations[0].Duration = (long)(timeAnimation * 1000000);
                        }
                    });
                }
                Proj.Materials.MaterialAnimations.AddRange(animations);

                // 3. Chèn Id animation tuần tự vào từng animation, cách nhau theo random
                int animationCount = Proj.Materials.MaterialAnimations.Count;

                // Chèn animation cách theo random
                step = step > 0 ? step + 1 : 1;

                int videoIndex = 0;
                int animationIndex = 0;
                // 2. Lặp qua list animation và video
                for (videoIndex = 0, animationIndex = 0; videoIndex < videoSegment.Count; videoIndex += step, animationIndex++)
                {
                    if (animationIndex > animations.Count - 1)
                        animationIndex = 0;
                    // 3. Thêm ID của animation vào material ref của video
                    videoSegment[videoIndex].ExtraMaterialRefs.Add(animations[animationIndex].Id);

                }
            }

            await Ctx.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Chèn transition vào video
        /// </summary>
        /// <param name="videoEffects"></param>
        /// <param name="timeEffect"></param> đơn vị tính phần trăm (%)
        /// <param name="isInsertToImageAndVideo"></param>
        /// <returns></returns>
        public async Task<bool> InsertEffect(List<VideoEffect> videoEffects, int timeEffect = 100, bool isInsertToImageAndVideo = false)
        {
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == TrackType.Video)?.Segments;
            if (videoSegment != null && videoSegment.Count > 0)
            {
                // 1. Xóa transition trong list video
                var effectMaterialsId = Proj.Materials.VideoEffects.Select(effect => effect.Id).Distinct().ToList();
                if (effectMaterialsId.Count > 0)
                {
                    // Clear transition ID in videeo
                    foreach (var video in videoSegment)
                    {
                        foreach (var id in effectMaterialsId)
                        {
                            video.ExtraMaterialRefs.Remove(id);
                        }
                    }
                }

                // 2. Xóa transition trong transition track
                var effectSegment = Proj.Tracks.FirstOrDefault(track => track.Type == TrackType.Effect)?.Segments;
                effectSegment?.Clear();

                // 3. Xóa transition trong material
                Proj.Materials.VideoEffects.Clear();

                // 4. Nếu áp dụng transition cho ảnh và video
                if (isInsertToImageAndVideo)
                {
                    // Chèn tuần tự từng transition vào material và ảnh, video tương ứng
                    int videoIndex = 0;
                    int effectIndex = 0;
                    // Lặp qua list transition và video
                    for (videoIndex = 0, effectIndex = 0; videoIndex < videoSegment.Count; videoIndex++, effectIndex++)
                    {
                        if (effectIndex > videoEffects.Count - 1)
                            effectIndex = 0;

                        var effect = videoEffects[effectIndex].DeepCopy();
                        effect.Id = Guid.NewGuid();

                        // Thêm vào material
                        Proj.Materials.VideoEffects.Add(effect);

                        // Thêm Id transition vào material của video
                        videoSegment[videoIndex].ExtraMaterialRefs.Add(effect.Id);
                    }
                }
                // 5. Ngược lại
                else
                {
                    // Chèn transition đầu tiên vào trong material
                    var effect = videoEffects.First().DeepCopy();
                    Proj.Materials.VideoEffects.Add(videoEffects.First());

                    // Effect start từ đầu video và thời gian của transition phục thuộc vào "Thời gian(%)" áp dụng cho video
                    var targetTimeRangeEffect = new TimeRange()
                    {
                        Duration = (Proj.Duration * timeEffect) / 100,
                        Start = 0
                    };

                    var effectTrack = Proj.Tracks.FirstOrDefault(track => track.Type == TrackType.Effect);
                    var effectSegmentNeedAdd = Track.Segment.CreateEffectSegment(Guid.NewGuid(), effect.Id, targetTimeRangeEffect);
                    if (effectTrack == null)
                    {
                        // Chèn transition segment vào track
                        Proj.Tracks.Add(new()
                        {
                            Id = new(),
                            Type = TrackType.Effect,
                            Segments = [effectSegmentNeedAdd]
                        });
                    }
                    else
                    {
                        effectTrack.Segments.Add(effectSegmentNeedAdd);
                    }
                }
            }
            await Ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> GetContext(string projectName = projectName)
        {
            try
            {
                string jsonFilePath = Path.Combine(projectFilePath, projectName);
                Ctx = new Context(jsonFilePath);
                Proj = await Ctx.GetProjectAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> InsertTransition(List<Transition> transitions, double time = 0.8)
        {
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == TrackType.Video)?.Segments;
            if (videoSegment != null && videoSegment.Count > 0)
            {
                // 1. Xóa transition trong video segment
                var transitionMaterialsId = Proj.Materials.Transitions.Select(tras => tras.Id).Distinct().ToList();
                if (transitionMaterialsId.Count > 0)
                {
                    // Clear transition ID in video
                    foreach (var video in videoSegment)
                    {
                        foreach (var id in transitionMaterialsId)
                        {
                            video.ExtraMaterialRefs.Remove(id);
                        }
                    }
                }

                // 2. Xóa transition trong material
                Proj.Materials.Transitions.Clear();

                // 3. Thêm tuần tự transition vào video và material
                int videoIndex = 0;
                int transitionIndex = 0;
                // Lặp qua list transition và video
                for (videoIndex = 0, transitionIndex = 0; videoIndex < videoSegment.Count; videoIndex++, transitionIndex++)
                {
                    if (transitionIndex > transitions.Count - 1)
                        transitionIndex = 0;

                    var transition = transitions[transitionIndex].DeepCopy();
                    transition.Id = Guid.NewGuid();
                    transition.Duration = time * 1000000;

                    // Thêm vào material
                    Proj.Materials.Transitions.Add(transition);

                    // Thêm Id transition vào material của video
                    videoSegment[videoIndex].ExtraMaterialRefs.Add(transition.Id);
                }
                await Ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
