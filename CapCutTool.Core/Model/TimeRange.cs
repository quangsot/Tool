using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Core.Model
{
    public class TimeRange : ICloneable<TimeRange>
    {
        public long Duration { get; set; }
        public long Start { get; set; }

        public TimeRange DeepCopy()
        {
            return (TimeRange)MemberwiseClone();
        }
    }
}
