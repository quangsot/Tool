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
    public class TransitionService(Context ctx, Config configs) : BaseService(ctx, configs), ITransitionService
    {
        public Task<bool> DeleteAllTransition()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertTransition(List<Transition> transitions, double time = 0.8)
        {
            var videoSegment = Proj.Tracks.FirstOrDefault(track => track.Type == _configs.Video)?.Segments;
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
