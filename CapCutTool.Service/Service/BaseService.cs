using CapCutTool.Core;
using CapCutTool.Core.Model;
using CapCutTool.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service.Service
{
    public class BaseService(Context ctx, Config configs) : IBaseService
    {

        protected readonly Config _configs = configs;

        private readonly Context ctx = ctx;
        private Project? proj;

        public Context Ctx { get => ctx; }
        public Project Proj { get => proj; }

        public async Task<bool> GetProject()
        {
            try
            {
                proj = await Ctx.GetProjectAsync();
                return true;
            }
            catch (Exception)
            {
                proj = null;
                return false;
            }
        }
    }
}
