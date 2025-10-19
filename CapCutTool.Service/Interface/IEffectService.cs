using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;

namespace CapCutTool.Service.Interface
{
    public interface IEffectService : IBaseService
    {
        Task<bool> InsertEffect(List<VideoEffect> videoEffects, int timeEffect = 100, bool isInsertToImageAndVideo = false);

        Task<bool> DeleteAllEffect();
    }
}
