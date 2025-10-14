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
        public string Type { get; set; }

        public abstract class MaterialDependent : Base
        {
            public Guid MaterialId { get; set; }
        }
        public List<Segment> Segments { get; set; }

        public class Segment : MaterialDependent, ICloneable<Segment>
        {
            [JsonPropertyName("source_timerange")]
            public TimeRange SourceTimerange { get; set; } = new();

            [JsonPropertyName("target_timerange")]
            public TimeRange TargetTimerange { get; set; } = new();

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

            public Segment DeepCopy()
            {
                var other = (Segment)MemberwiseClone();
                other.SourceTimerange = SourceTimerange.DeepCopy();
                other.TargetTimerange = TargetTimerange.DeepCopy();
                other.ExtraMaterialRefs = [.. ExtraMaterialRefs];
                return other;
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
