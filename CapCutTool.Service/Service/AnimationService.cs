using CapCutTool.Core;
using CapCutTool.Core.Model;
using CapCutTool.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;

namespace CapCutTool.Service.Service
{
    public class AnimationService(Context ctx, Config configs) : BaseService(ctx, configs), IAnimationService
    {
        public Task<bool> DeleteAllAnimation()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAnimation(List<MaterialAnimation> animations, int step = 0, float timeAnimation = 0)
        {
            // Lấy video animation
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Video)?.Segments;
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
    }
}
