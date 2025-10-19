using CapCutTool.Core;
using CapCutTool.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service.Service
{
    public class VoiceService(Context ctx, Config configs) : BaseService(ctx, configs), IVoiceService
    {
        public async Task<bool> SyncVoid()
        {
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Video)?.Segments;
            var audioSegment = Proj.Tracks.First(t => t.Type == _configs.Audio).Segments;
            if ((videoSegment != null && videoSegment.Count > 0) && (audioSegment != null && audioSegment.Count > 0))
            {
                long timePoint = 0;
                var numOfSegment = Math.Min(videoSegment.Count, audioSegment.Count);
                var typeOfVideo = string.Empty;
                int index = 0;

                for (index = 0; index < numOfSegment; index++)
                {
                    var materialVideo = Proj.Materials.Videos.Single(v => v.Id == videoSegment[index].MaterialId);
                    if (materialVideo != null)
                    {
                        typeOfVideo = materialVideo?.Type;

                        if (typeOfVideo == _configs.Photo)
                        {
                            // lấy thời gian của audio
                            var audioTime = audioSegment[index].SourceTimerange?.Duration ?? 0;

                            // đồng nhất thời gian duration
                            // gán thời gian của material video = thời gian của audio
                            materialVideo.Duration = audioTime;

                            // gán thời gian source của segment video = thời gian của audio
                            videoSegment[index].SourceTimerange.Duration = audioTime;

                            // gán thời gian target của segment video =  thời gian của audio
                            videoSegment[index].TargetTimerange.Duration = audioTime;

                            // đồng nhất thời điểm start
                            // Gán thời gian bắt đầu bằng videoTimePoint
                            videoSegment[index].TargetTimerange.Start = timePoint;
                            audioSegment[index].TargetTimerange.Start = timePoint;

                            // Cộng dồn thời gian của video với videoTimePoint
                            timePoint += audioTime;
                        }
                        else if (typeOfVideo == _configs.Video)
                        {
                            // lấy time của audio và video
                            var videoTime = videoSegment[index].TargetTimerange?.Duration ?? 0;
                            var audioTime = audioSegment[index].SourceTimerange?.Duration ?? 0;

                            // đồng nhất thời điểm start
                            videoSegment[index].TargetTimerange.Start = timePoint;
                            audioSegment[index].TargetTimerange.Start = timePoint;

                            // cộng dồn thời gian của video vào video TimePoint
                            var startNextTime = Math.Max(audioTime, videoTime);
                            timePoint += startNextTime;
                        }
                    }
                }
                await Ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
