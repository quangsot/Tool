using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapCutTool.Core.Json
{
    public class PropperCaseGuidJsonConverter : JsonConverter<Guid>
    {
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Guid.TryParse(reader.GetString(), out Guid result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            const char separator = '-';
            var parts = value.ToString().Split(separator).Select((s, i) => i == 2 ? s.ToLower() : s.ToUpper());
            writer.WriteStringValue(string.Join(separator, parts));
            //writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}
