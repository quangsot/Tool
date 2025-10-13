using System.Text.Json.Serialization;

namespace CapCutTool.Core.Model
{
    public abstract class Base
    {
        public Guid Id { get; set; }

        public const string TemplateIdName = "$template_id";

        [JsonIgnore]
        public Guid? TemplateId { get; set; }
    }
}
