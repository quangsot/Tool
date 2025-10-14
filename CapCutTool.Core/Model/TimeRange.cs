using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapCutTool.Core.Model
{
    public class TimeRange : ICloneable<TimeRange>
    {
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("start")]
        public long Start { get; set; }

        public TimeRange DeepCopy()
        {
            return (TimeRange)MemberwiseClone();
        }
    }
}
