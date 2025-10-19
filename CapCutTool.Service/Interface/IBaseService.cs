using CapCutTool.Core.Model;
using CapCutTool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service.Interface
{
    public interface IBaseService
    {
        Context Ctx { get; }
        Project Proj { get; }

        Task<bool> GetProject();

    }
}
