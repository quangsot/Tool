using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service
{
    public class VideoSegment
    {
        public string Id { get; set; }

        public string MaterialId { get; set; }

        public TimeRange Source { get; set; }

        public TimeRange Target { get; set; }
    }
}
