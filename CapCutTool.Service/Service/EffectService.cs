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
    public class EffectService(Context ctx, Config configs) : BaseService(ctx, configs), IEffectService
    {
        public Task<bool> DeleteAllEffect()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertEffect(List<VideoEffect> videoEffects, int timeEffect = 100, bool isInsertToImageAndVideo = false)
        {
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Video)?.Segments;
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
                var effectSegment = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Effect)?.Segments;
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

                    var effectTrack = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Effect);
                    var effectSegmentNeedAdd = Track.Segment.CreateEffectSegment(Guid.NewGuid(), effect.Id, targetTimeRangeEffect);
                    if (effectTrack == null)
                    {
                        // Chèn transition segment vào track
                        Proj.Tracks.Add(new()
                        {
                            Id = new(),
                            Type = _configs.Effect,
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
    }
}
