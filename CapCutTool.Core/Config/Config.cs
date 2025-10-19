using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Core
{
    public class Config
    {
        public string Video { get; set; } = default!;
        public string Effect { get; set; } = default!;
        public string Audio { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public string ProjectFile { get; set; } = default!;
        public string ProjectFilePath { get; set; } = default!;
        public string CurentProject { get; set; } = default!;
        public List<string> ListProject { get; set; } = [];

    }

}
