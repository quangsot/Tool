using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service.Interface
{
    public interface IVoiceService : IBaseService
    {
        Task<bool> SyncVoid();
    }
}
