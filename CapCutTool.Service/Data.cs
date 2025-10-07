using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service
{
    class Data
    {
        
        public static List<string> Animations = [SlideUpAnimation, FocusAnimation, BlurInAnimation, RotaryExpanderAnimation, EnergyBoomAnimation];

        public static List<string> Effects = [CameraMovementEffect, BlurryFocusEffect, FaultySignalEffect, BlackNoiseEffect, ParticleBlur2Effect];

        #region Animation
        private const string SlideUpAnimation = @"{
                ""animations"": [
                    {
                        ""anim_adjust_params"": null,
                        ""category_id"": ""6824"",
                        ""category_name"": ""In"",
                        ""duration"": 500000,
                        ""id"": ""6798333487523828238"",
                        ""material_type"": ""video"",
                        ""name"": ""Slide Up"",
                        ""panel"": ""video"",
                        ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/6798333487523828238/51657913dffa9f4c5f9d4411b53611e5"",
                        ""platform"": ""all"",
                        ""request_id"": ""20250929205558E5C2750E93778132A04E"",
                        ""resource_id"": ""6798333487523828238"",
                        ""source_platform"": 1,
                        ""start"": 0,
                        ""third_resource_id"": ""6798333487523828238"",
                        ""type"": ""in""
                    }
                ],
                ""id"": ""3B44C2CA-576D-4c23-9E6E-EADF042685B0"",
                ""multi_language_current"": ""none"",
                ""type"": ""sticker_animation""
        }";

        private const string FocusAnimation = @"{
                ""animations"": [
                    {
                        ""anim_adjust_params"": null,
                        ""category_id"": ""6824"",
                        ""category_name"": ""In"",
                        ""duration"": 1200000,
                        ""id"": ""7340857216053809666"",
                        ""material_type"": ""video"",
                        ""name"": ""Focus"",
                        ""panel"": ""video"",
                        ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7340857216053809666/d67cbf9a7ae88abc4359e37ab06a5562"",
                        ""platform"": ""all"",
                        ""request_id"": ""2025093002091005FC2ADE09DBB85651EC"",
                        ""resource_id"": ""7340857216053809666"",
                        ""source_platform"": 1,
                        ""start"": 0,
                        ""third_resource_id"": ""7340857216053809666"",
                        ""type"": ""in""
                    }
                ],
                ""id"": ""c10ddef8-af88-4592-8ecd-2b253554ac95"",
                ""multi_language_current"": ""none"",
                ""type"": ""sticker_animation""
        }";

        private const string BlurInAnimation = @"{
                ""animations"": [
                    {
                        ""anim_adjust_params"": null,
                        ""category_id"": ""6824"",
                        ""category_name"": ""In"",
                        ""duration"": 1000000,
                        ""id"": ""7507508671341956368"",
                        ""material_type"": ""video"",
                        ""name"": ""Blur In"",
                        ""panel"": ""video"",
                        ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7507508671341956368/8cae31085133e4f866a2b69a3d433658"",
                        ""platform"": ""all"",
                        ""request_id"": ""20251007232434AA5FB510915F075601A4"",
                        ""resource_id"": ""7507508671341956368"",
                        ""source_platform"": 1,
                        ""start"": 0,
                        ""third_resource_id"": ""0"",
                        ""type"": ""in""
                    }
                ],
                ""id"": ""3EB38A31-8E52-4540-B75E-FB85196FA46B"",
                ""multi_language_current"": ""none"",
                ""type"": ""sticker_animation""
            }";

        private const string RotaryExpanderAnimation = @"{
                ""animations"": [
                    {
                        ""anim_adjust_params"": null,
                        ""category_id"": ""6824"",
                        ""category_name"": ""In"",
                        ""duration"": 1330000,
                        ""id"": ""7542692404046908733"",
                        ""material_type"": ""video"",
                        ""name"": ""Rotary Expander"",
                        ""panel"": ""video"",
                        ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7542692404046908733/7a0774fff81084c1be514701f0eca7c7"",
                        ""platform"": ""all"",
                        ""request_id"": ""20251007232434AA5FB510915F075601A4"",
                        ""resource_id"": ""7542692404046908733"",
                        ""source_platform"": 1,
                        ""start"": 0,
                        ""third_resource_id"": ""0"",
                        ""type"": ""in""
                    }
                ],
                ""id"": ""E2029C14-B467-472c-A66E-34462FDDE152"",
                ""multi_language_current"": ""none"",
                ""type"": ""sticker_animation""
            }";

        private const string EnergyBoomAnimation = @"{
                ""animations"": [
                    {
                        ""anim_adjust_params"": null,
                        ""category_id"": ""6824"",
                        ""category_name"": ""In"",
                        ""duration"": 2000000,
                        ""id"": ""7545680109089361213"",
                        ""material_type"": ""video"",
                        ""name"": ""Energy Boom"",
                        ""panel"": ""video"",
                        ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7545680109089361213/f043f2ee56c25dc029ca5ad8d1f25223"",
                        ""platform"": ""all"",
                        ""request_id"": ""20251007232434AA5FB510915F075601A4"",
                        ""resource_id"": ""7545680109089361213"",
                        ""source_platform"": 1,
                        ""start"": 0,
                        ""third_resource_id"": ""0"",
                        ""type"": ""in""
                    }
                ],
                ""id"": ""5BA357EA-AEF9-4905-9BBA-01F8A3F132C1"",
                ""multi_language_current"": ""none"",
                ""type"": ""sticker_animation""
            }";
        #endregion

        #region Effect
        private const string CameraMovementEffect = @"{
                ""adjust_params"": [
                    {
                        ""default_value"": 0.35,
                        ""name"": ""effects_adjust_speed"",
                        ""value"": 0.35
                    },
                    {
                        ""default_value"": 0.8,
                        ""name"": ""effects_adjust_intensity"",
                        ""value"": 0.8
                    },
                    {
                        ""default_value"": 1.0,
                        ""name"": ""effects_adjust_blur"",
                        ""value"": 1.0
                    },
                    {
                        ""default_value"": 0.8,
                        ""name"": ""effects_adjust_luminance"",
                        ""value"": 0.8
                    },
                    {
                        ""default_value"": 0.8,
                        ""name"": ""effects_adjust_size"",
                        ""value"": 0.8
                    }
                ],
                ""algorithm_artifact_path"": """",
                ""apply_target_type"": 2,
                ""apply_time_range"": null,
                ""bind_segment_id"": """",
                ""category_id"": ""27296"",
                ""category_name"": ""Trending"",
                ""common_keyframes"": [],
                ""covering_relation_change"": 0,
                ""disable_effect_faces"": [],
                ""effect_id"": ""7399472023874948357"",
                ""effect_mask"": [],
                ""enable_mask"": true,
                ""formula_id"": """",
                ""id"": ""D9D14A53-10E8-4175-9F79-84A0A4F55F6E"",
                ""item_effect_type"": 0,
                ""name"": ""Camera Movement"",
                ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7399472023874948357/bbc5f812f50b8ea1aadb3fd6ac2dd6f0"",
                ""platform"": ""all"",
                ""render_index"": 0,
                ""request_id"": ""202510072326467FFCC877AC8BBD57B4D1"",
                ""resource_id"": ""7399472023874948357"",
                ""source_platform"": 1,
                ""sub_type"": 0,
                ""time_range"": null,
                ""track_render_index"": 0,
                ""transparent_params"": """",
                ""type"": ""video_effect"",
                ""value"": 1.0,
                ""version"": """"
            }";

        private const string BlurryFocusEffect = @"{
                ""adjust_params"": [
                    {
                        ""default_value"": 0.33,
                        ""name"": ""effects_adjust_speed"",
                        ""value"": 0.33
                    },
                    {
                        ""default_value"": 0.25,
                        ""name"": ""effects_adjust_blur"",
                        ""value"": 0.25
                    }
                ],
                ""algorithm_artifact_path"": """",
                ""apply_target_type"": 2,
                ""apply_time_range"": null,
                ""bind_segment_id"": """",
                ""category_id"": ""27296"",
                ""category_name"": ""Trending"",
                ""common_keyframes"": [],
                ""covering_relation_change"": 0,
                ""disable_effect_faces"": [],
                ""effect_id"": ""7399468886309162246"",
                ""effect_mask"": [],
                ""enable_mask"": true,
                ""formula_id"": """",
                ""id"": ""950B84DA-A0D9-46b1-A0FE-625DD2BAB198"",
                ""item_effect_type"": 0,
                ""name"": ""Blurry Focus"",
                ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7399468886309162246/5dd4bf7e879fe7356e3e27e5105f5af1"",
                ""platform"": ""all"",
                ""render_index"": 0,
                ""request_id"": ""202510020030035CD55A5D9D21FA51D354"",
                ""resource_id"": ""7399468886309162246"",
                ""source_platform"": 1,
                ""sub_type"": 0,
                ""time_range"": null,
                ""track_render_index"": 0,
                ""transparent_params"": """",
                ""type"": ""video_effect"",
                ""value"": 1.0,
                ""version"": """"
            }";

        private const string FaultySignalEffect = @"{
                ""adjust_params"": [
                    {
                        ""default_value"": 0.09090909090909,
                        ""name"": ""effects_adjust_speed"",
                        ""value"": 0.09090909090909
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_filter"",
                        ""value"": 0.5
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_noise"",
                        ""value"": 0.5
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_sharpen"",
                        ""value"": 0.5
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_intensity"",
                        ""value"": 0.5
                    }
                ],
                ""algorithm_artifact_path"": """",
                ""apply_target_type"": 2,
                ""apply_time_range"": null,
                ""bind_segment_id"": """",
                ""category_id"": ""27296"",
                ""category_name"": ""Trending"",
                ""common_keyframes"": [],
                ""covering_relation_change"": 0,
                ""disable_effect_faces"": [],
                ""effect_id"": ""7426268842642379265"",
                ""effect_mask"": [],
                ""enable_mask"": true,
                ""formula_id"": """",
                ""id"": ""4410E3A2-DD9E-4207-BB26-4BC99D193F8A"",
                ""item_effect_type"": 0,
                ""name"": ""Faulty Signal"",
                ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7426268842642379265/1f7b111effe937c3ec574a0791866cf9"",
                ""platform"": ""all"",
                ""render_index"": 0,
                ""request_id"": ""202510072326467FFCC877AC8BBD57B4D1"",
                ""resource_id"": ""7426268842642379265"",
                ""source_platform"": 1,
                ""sub_type"": 0,
                ""time_range"": null,
                ""track_render_index"": 0,
                ""transparent_params"": """",
                ""type"": ""video_effect"",
                ""value"": 1.0,
                ""version"": """"
            }";

        private const string BlackNoiseEffect = @"{
                ""adjust_params"": [
                    {
                        ""default_value"": 0.33,
                        ""name"": ""effects_adjust_speed"",
                        ""value"": 0.33
                    }
                ],
                ""algorithm_artifact_path"": """",
                ""apply_target_type"": 2,
                ""apply_time_range"": null,
                ""bind_segment_id"": """",
                ""category_id"": ""27296"",
                ""category_name"": ""Trending"",
                ""common_keyframes"": [],
                ""covering_relation_change"": 0,
                ""disable_effect_faces"": [],
                ""effect_id"": ""7399470796290166022"",
                ""effect_mask"": [],
                ""enable_mask"": true,
                ""formula_id"": """",
                ""id"": ""76EACB3F-9E6D-4128-B9BF-B82B4D50FA7D"",
                ""item_effect_type"": 0,
                ""name"": ""Black Noise"",
                ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7399470796290166022/e7baebcf969437d4d5cdb607578bbf89"",
                ""platform"": ""all"",
                ""render_index"": 0,
                ""request_id"": ""202510072326467FFCC877AC8BBD57B4D1"",
                ""resource_id"": ""7399470796290166022"",
                ""source_platform"": 1,
                ""sub_type"": 0,
                ""time_range"": null,
                ""track_render_index"": 0,
                ""transparent_params"": """",
                ""type"": ""video_effect"",
                ""value"": 1.0,
                ""version"": """"
            }";

        private const string ParticleBlur2Effect = @"{
                ""adjust_params"": [
                    {
                        ""default_value"": 1.0,
                        ""name"": ""effects_adjust_blur"",
                        ""value"": 1.0
                    },
                    {
                        ""default_value"": 0.33333333333,
                        ""name"": ""effects_adjust_speed"",
                        ""value"": 0.33333333333
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_horizontal_shift"",
                        ""value"": 0.5
                    },
                    {
                        ""default_value"": 0.5,
                        ""name"": ""effects_adjust_vertical_shift"",
                        ""value"": 0.5
                    }
                ],
                ""algorithm_artifact_path"": """",
                ""apply_target_type"": 2,
                ""apply_time_range"": null,
                ""bind_segment_id"": """",
                ""category_id"": ""27296"",
                ""category_name"": ""Trending"",
                ""common_keyframes"": [],
                ""covering_relation_change"": 0,
                ""disable_effect_faces"": [],
                ""effect_id"": ""7399470035938381062"",
                ""effect_mask"": [],
                ""enable_mask"": true,
                ""formula_id"": """",
                ""id"": ""15B8E48F-777F-4b68-A36D-9151B2F6A814"",
                ""item_effect_type"": 0,
                ""name"": ""Particle Blur 2"",
                ""path"": ""C:/Users/ADMIN/AppData/Local/CapCut/User Data/Cache/effect/7399470035938381062/dab36cd2d944de4611f0040921c550a6"",
                ""platform"": ""all"",
                ""render_index"": 0,
                ""request_id"": ""202510020030035CD55A5D9D21FA51D354"",
                ""resource_id"": ""7399470035938381062"",
                ""source_platform"": 1,
                ""sub_type"": 0,
                ""time_range"": null,
                ""track_render_index"": 0,
                ""transparent_params"": """",
                ""type"": ""video_effect"",
                ""value"": 1.0,
                ""version"": """"
            }";
        #endregion
    }
}
