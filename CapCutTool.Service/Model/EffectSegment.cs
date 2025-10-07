using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service
{
    public class EffectSegment
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string MaterialId { get; private set; } = string.Empty;

        public TimeRange Target { get; set; }


        private string effectSegmentTemplate = @"{
                    ""caption_info"": null,
                    ""cartoon"": false,
                    ""clip"": null,
                    ""color_correct_alg_result"": """",
                    ""common_keyframes"": [],
                    ""desc"": """",
                    ""digital_human_template_group_id"": """",
                    ""enable_adjust"": false,
                    ""enable_adjust_mask"": false,
                    ""enable_color_correct_adjust"": false,
                    ""enable_color_curves"": true,
                    ""enable_color_match_adjust"": false,
                    ""enable_color_wheels"": true,
                    ""enable_hsl"": false,
                    ""enable_hsl_curves"": true,
                    ""enable_lut"": false,
                    ""enable_smart_color_adjust"": false,
                    ""enable_video_mask"": true,
                    ""extra_material_refs"": [],
                    ""group_id"": """",
                    ""hdr_settings"": null,
                    ""id"": """",
                    ""intensifies_audio"": false,
                    ""is_loop"": false,
                    ""is_placeholder"": false,
                    ""is_tone_modify"": false,
                    ""keyframe_refs"": [],
                    ""last_nonzero_volume"": 1.0,
                    ""lyric_keyframes"": null,
                    ""material_id"": """",
                    ""raw_segment_id"": """",
                    ""render_index"": 0,
                    ""render_timerange"": {
                        ""duration"": 0,
                        ""start"": 0
                    },
                    ""responsive_layout"": {
                        ""enable"": false,
                        ""horizontal_pos_layout"": 0,
                        ""size_layout"": 0,
                        ""target_follow"": """",
                        ""vertical_pos_layout"": 0
                    },
                    ""reverse"": false,
                    ""source"": ""segmentsourcenormal"",
                    ""source_timerange"": null,
                    ""speed"": 1.0,
                    ""state"": 0,
                    ""target_timerange"": {
                        ""duration"": 3000000,
                        ""start"": 4000000
                    },
                    ""template_id"": """",
                    ""template_scene"": ""default"",
                    ""track_attribute"": 0,
                    ""track_render_index"": 1,
                    ""uniform_scale"": null,
                    ""visible"": true,
                    ""volume"": 1.0
                }";

        private double defaultTargetTimeRange = 3000000;

        public JObject? GenerateEffect(string effectMaterialJson)
        {
            if (Data.Effects.Contains(effectMaterialJson))
            {
                var effect = JObject.Parse(effectSegmentTemplate);
                var effectMaterial = JObject.Parse(effectMaterialJson);

                var idEffectMaterial = effect["id"];

                effect.SelectToken("id")?.Replace(Id);
                effect.SelectToken("material_id")?.Replace(effect["id"]);
                effect.SelectToken("target_timerange.duration")?.Replace(defaultTargetTimeRange);
                effect.SelectToken("target_timerange.start")?.Replace(Target.Start);

                return effect;
            }
            

            return null;
        }
    }
}
