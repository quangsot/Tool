using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;

namespace CapCutTool.Service.Interface
{
    public interface IAnimationService : IBaseService
    {
        Task<bool> InsertAnimation(List<MaterialAnimation> animations, int randomNum, float timeAnimation);

        Task<bool> DeleteAllAnimation();
    }
}
