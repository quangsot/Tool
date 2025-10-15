using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapCutTool.Core.Model
{
    public class Track : Base
    {
        public string Type { get; set; } = string.Empty;

        public int Attribute { get; set; }
        public int Flag { get; set; }
        public bool IsDefaultName { get; set; }
        public string Name { get; set; }

        public abstract class MaterialDependent : Base
        {
            public Guid MaterialId { get; set; }
        }
        public List<Segment> Segments { get; set; } = [];

        public class Segment : MaterialDependent, ICloneable<Segment>
        {
            [JsonPropertyName("source_timerange")]
            public TimeRange? SourceTimerange { get; set; }

            [JsonPropertyName("target_timerange")]
            public TimeRange? TargetTimerange { get; set; }

            #region CommonKeyFrame
            //public List<CommonKeyFrame> CommonKeyframes { get; set; }
            //public class CommonKeyFrame : MaterialDependent, ICloneable<CommonKeyFrame>
            //{
            //    public Guid MaterialId { get; set; }

            //    public string PropertyType { get; set; }

            //    public class KeyFrame : Base, ICloneable<KeyFrame>
            //    {
            //        /*
            //        [JsonPropertyName("curveType")]
            //        public string CurveType { get; set; }

            //        [JsonPropertyName("graphID")]
            //        public string GraphId { get; set; }

            //        public PointF LeftControl { get; set; }

            //        public PointF RightControl { get; set; }

            //        public string StringValue { get; set; }
            //        */

            //        public long TimeOffset { get; set; }

            //        public List<double>? Values { get; set; }

            //        public KeyFrame DeepCopy()
            //        {
            //            var other = (KeyFrame)MemberwiseClone();
            //            other.Values = Values?
            //                .ToList();
            //            return other;
            //        }
            //    }

            //    public List<KeyFrame>? KeyframeList { get; set; }

            //    public CommonKeyFrame DeepCopy()
            //    {
            //        var other = (CommonKeyFrame)MemberwiseClone();
            //        other.KeyframeList = KeyframeList?
            //            .Select(kf => kf.DeepCopy())
            //            .ToList();
            //        return other;
            //    }
            //}
            #endregion

            [JsonPropertyName("extra_material_refs")]
            public List<Guid> ExtraMaterialRefs { get; set; } = [];
            public object? CaptionInfo { get; set; }
            public bool Cartoon { get; set; }
            public object? Clip { get; set; }
            public string ColorCorrectAlgResult { get; set; } = string.Empty;
            public List<object> CommonKeyframes { get; set; } = new();
            public string Desc { get; set; } = string.Empty;
            public string DigitalHumanTemplateGroupId { get; set; } = string.Empty;
            public bool EnableAdjust { get; set; }
            public bool EnableAdjustMask { get; set; }
            public bool EnableColorCorrectAdjust { get; set; }
            public bool EnableColorCurves { get; set; } = true;
            public bool EnableColorMatchAdjust { get; set; }
            public bool EnableColorWheels { get; set; } = true;
            public bool EnableHsl { get; set; }
            public bool EnableHslCurves { get; set; } = true;
            public bool EnableLut { get; set; }
            public bool EnableSmartColorAdjust { get; set; }
            public bool EnableVideoMask { get; set; } = true;
            public string GroupId { get; set; } = string.Empty;
            public object? HdrSettings { get; set; }
            public new Guid Id { get; set; }
            public bool IntensifiesAudio { get; set; }
            public bool IsLoop { get; set; }
            public bool IsPlaceholder { get; set; }
            public bool IsToneModify { get; set; }
            public List<object> KeyframeRefs { get; set; } = new();
            public double LastNonzeroVolume { get; set; } = 1;
            public object? LyricKeyframes { get; set; }
            public string RawSegmentId { get; set; } = string.Empty;
            public int RenderIndex { get; set; }
            public TimeRange RenderTimerange { get; set; } = new();
            public ResponsiveLayoutSegment ResponsiveLayout { get; set; } = new();
            public bool Reverse { get; set; }
            public string Source { get; set; } = "segmentsourcenormal";
            public double Speed { get; set; } = 1;
            public int State { get; set; }
            public new string TemplateId { get; set; } = string.Empty;
            public string TemplateScene { get; set; } = "default";
            public int TrackAttribute { get; set; }
            public int TrackRenderIndex { get; set; }
            public object? UniformScale { get; set; }
            public bool Visible { get; set; }
            public double Volume { get; set; } = 1;


            public class ResponsiveLayoutSegment : ICloneable<ResponsiveLayoutSegment>
            {
                public bool Enable { get; set; }
                public int HorizontalPosLayout { get; set; }
                public int SizeLayout { get; set; }
                public string TargetFollow { get; set; } = string.Empty;
                public int VerticalPosLayout { get; set; }

                public ResponsiveLayoutSegment DeepCopy()
                {
                    return this.MemberwiseClone() as ResponsiveLayoutSegment ?? new();
                }
            }

            public Segment DeepCopy()
            {
                var other = (Segment)MemberwiseClone();
                other.SourceTimerange = SourceTimerange.DeepCopy();
                other.TargetTimerange = TargetTimerange.DeepCopy();
                other.ExtraMaterialRefs = [.. ExtraMaterialRefs];
                other.ResponsiveLayout = ResponsiveLayout.DeepCopy();
                return other;
            }

            public static Segment CreateEffectSegment(Guid id, Guid materialId, TimeRange target)
            {
                return new Segment()
                {
                    Id = id,
                    MaterialId = materialId,
                    SourceTimerange = null,
                    TargetTimerange = target,
                    TrackRenderIndex = 2,
                    Visible = true
                };
            }

            //public void SetHorizontalAppearance(params (long Time, double Value)[] keyFrames)
            //{
            //    var kfListX = CommonKeyframes
            //        .Single(kf => kf.PropertyType == "KFTypeCommonMaskPositionX")
            //        .KeyframeList!;

            //    Track.Segment.CommonKeyFrame.KeyFrame? prevKF = default;
            //    for (var i = 0; i < 3; i++)
            //    {
            //        var (Time, Value) = keyFrames[i];
            //        var kfOut = kfListX[i];
            //        kfOut.TimeOffset = Time;
            //        if (prevKF != default)
            //        {
            //            kfOut.TimeOffset += prevKF.TimeOffset;
            //        }
            //        kfOut.Values = [Value];
            //        prevKF = kfOut;
            //    }
            //}
        }

    }
}
