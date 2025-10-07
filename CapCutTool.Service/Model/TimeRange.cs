using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service
{
    public class TimeRange
    {
        public TimeRange()
        {
        }

        public TimeRange(double duration, double start)
        {
            Duration = duration;
            Start = start;
        }

        public double Duration { get; set; }

        public double Start { get; set; }
    }
}
