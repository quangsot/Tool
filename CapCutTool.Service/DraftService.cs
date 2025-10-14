using CapCutTool.Core;
using CapCutTool.Core.Model;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapCutTool.Service
{
    public interface IDraftService
    {
        Task<bool> GetContext(string projectName);
        Task<bool> InsertAnimation(List<MaterialAnimation> animations, int randomNum, float timeAnimation);
        Task<bool> InsertEffect();
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

        //public async Task<bool> InsertAnimation()
        //{
        //    try
        //    {
        //        var root = await CommonUtil.GetJsonContent(projectName);

        //        var segments = (JArray?)root.SelectToken("tracks[0].segments") ?? [];
        //        var materialAnimations = (JArray?)root.SelectToken("materials.material_animations");
        //        materialAnimations?.Clear();

        //        List<string> listAnimation = Data.Animations;
        //        int videoIndex = 0;
        //        foreach (var animation in segments)
        //        {
        //            if (videoIndex == listAnimation.Count) videoIndex = 0;
        //            while (videoIndex < listAnimation.Count)
        //            {
        //                var newAnimation = JObject.Parse(listAnimation[videoIndex]);
        //                materialAnimations?.Add(newAnimation);

        //                var materialRef = (JArray?)animation.SelectToken("extra_material_refs");
        //                materialRef?.Add(newAnimation["id"]);

        //                videoIndex++;
        //                break;
        //            }
        //        }

        //        CommonUtil.SaveJsonContent(root, projectName);
        //        return true;

        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        public async Task<bool> InsertEffect()
        {
            return await Task.FromResult(true);
            //try
            //{
            //    var root = await CommonUtil.GetJsonContent(projectName);

            //    // 1.Clear Effects list
            //    CommonUtil.ClearEffectList(root);

            //    // 2. Create Effects Segment
            //    var effects = Data.Effects;

            //    // add effect to material
            //    CommonUtil.AddEffectToMaterial(root, effects);

            //    // Get list video
            //    var videos = CommonUtil.GetVideoSegments(root);

            //    foreach (var video in videos)
            //    {
            //        // create effect
            //        var effectSegment = new EffectSegment()
            //        {
            //            Target = new TimeRange()
            //            {
            //                Start = video.Target.Start
            //            }
            //        };

            //        int effectIndex = videos.IndexOf(video) % effects.Count;
            //        var effectSegmentObject = effectSegment.GenerateEffect(effects[effectIndex]);

            //        // add effectSegment to track effect
            //        CommonUtil.AddEffectToSegment(root, effectSegmentObject);
            //    }

            //    // 3. Save
            //    CommonUtil.SaveJsonContent(root, projectName);

            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

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
    }
}
