using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;

namespace CapCutTool.Service.Interface
{
    public interface ITransitionService : IBaseService
    {
        Task<bool> InsertTransition(List<Transition> transitions, double time = 1);

        Task<bool> DeleteAllTransition();
    }
}
