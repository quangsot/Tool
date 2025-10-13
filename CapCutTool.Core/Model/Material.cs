using CapCutTool.Core.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapCutTool.Core.Model
{
    public partial class Materials
    {
        public abstract class Material : Base;

        public List<MaterialAnimation> MaterialAnimations { get; set; } = [];

        public List<Video> Videos { get; set; }

        public class MaterialAnimation : Base
        {
            [JsonPropertyName("animations")]
            public List<Animation> Animations { get; set; }


            [JsonPropertyName("multi_language_current")]
            public string MultiLanguageCurrent { get; set; }


            [JsonPropertyName("type")]
            public string Type { get; set; }


            public class Animation
            {
                [JsonPropertyName("anim_adjust_params")]
                public object AnimAdjustParams { get; set; }

                [JsonPropertyName("category_id")]
                public string CategoryId { get; set; }

                [JsonPropertyName("category_name")]
                public string CategoryName { get; set; }

                [JsonPropertyName("duration")]
                public long Duration { get; set; }

                [JsonPropertyName("id")]
                public string Id { get; set; }

                [JsonPropertyName("material_type")]
                public string MaterialType { get; set; }

                [JsonPropertyName("name")]
                public string Name { get; set; }

                [JsonPropertyName("panel")]
                public string Panel { get; set; }

                [JsonPropertyName("path")]
                public string Path { get; set; }

                [JsonPropertyName("platform")]
                public string Platform { get; set; }

                [JsonPropertyName("request_id")]
                public string RequestId { get; set; }

                [JsonPropertyName("resource_id")]
                public string ResourceId { get; set; }

                [JsonPropertyName("source_platform")]
                public int SourcePlatform { get; set; }

                [JsonPropertyName("start")]
                public int Start { get; set; }

                [JsonPropertyName("third_resource_id")]
                public string ThirdResourceId { get; set; }

                [JsonPropertyName("type")]
                public string Type { get; set; }
            }
        }

        public class Video : Material
        {
            //public Guid LocalMaterialId { get; set; }

            [JsonInclude]
            public string MaterialName { get; private set; }

            [JsonInclude]
            public string Path { get; private set; }

            public void ChangePath(string path)
            {
                Path = path;
                MaterialName = System.IO.Path.GetFileName(Path);
            }
        }

        //public abstract class ConstantMaterial : Material, ICloneable<ConstantMaterial>
        //{
        //    public Guid ConstantMaterialId { get; set; }

        //    public virtual ConstantMaterial DeepCopy()
        //    {
        //        var other = (ConstantMaterial)MemberwiseClone();
        //        other.ConstantMaterialId = ConstantMaterialId;
        //        return other;
        //    }
        //}

        #region Text
        //public List<Text> Texts { get; set; }
        //public class Text : Material, ICloneable<Text>
        //{
        //    [JsonConverter(typeof(JsonEncodedStringToObjectConverter<ContentObj>))]
        //    public ContentObj Content { get; set; }

        //    public Text DeepCopy()
        //    {
        //        var other = (Text)MemberwiseClone();
        //        other.Content = Content?.DeepCopy();
        //        return other;
        //    }

        //    #region ContentObj
        //    //public class ContentObj : ICloneable<ContentObj>
        //    //{
        //    //    public string Text { get; set; }

        //    //    public class Style
        //    //    {
        //    //        public Fill Fill { get; set; }

        //    //        public Font Font { get; set; }

        //    //        public List<Stroke> Strokes { get; set; }

        //    //        public double Size { get; set; }

        //    //        public bool UseLetterColor { get; set; }

        //    //        public int[] Range { get; set; }

        //    //        public Style DeepCopy()
        //    //        {
        //    //            var other = (Style)MemberwiseClone();
        //    //            other.Fill = Fill?.DeepCopy();
        //    //            other.Font = Font?.DeepCopy();
        //    //            other.Strokes = Strokes?
        //    //                .Select(s => s.DeepCopy())
        //    //                .ToList();
        //    //            other.Range = Range?.ToArray();

        //    //            return other;
        //    //        }
        //    //    }

        //    //    public List<Style>? Styles { get; set; }

        //    //    public ContentObj DeepCopy()
        //    //    {
        //    //        var other = (ContentObj)MemberwiseClone();
        //    //        other.Styles = Styles?
        //    //            .Select(s => s.DeepCopy())
        //    //            .ToList();
        //    //        return other;
        //    //    }

        //    //    public void Highlight(Style background, Style highlight, int[] columnWidths, params (int row, int column)[] cells)
        //    //    {
        //    //        Styles = [];
        //    //        var thisStyle = background.DeepCopy();
        //    //        thisStyle.Range[0] = 0;
        //    //        void FinalizeStyle(int end)
        //    //        {
        //    //            thisStyle.Range[1] = end;
        //    //            Styles.Add(thisStyle);
        //    //        }
        //    //        foreach ((var row, var column) in cells
        //    //            .OrderBy(c => c.row)
        //    //            .ThenBy(c => c.column))
        //    //        {
        //    //            var charIndex = (columnWidths.Sum() + columnWidths.Length) * (row + 1) + columnWidths[0..(column)].Sum() + column;
        //    //            FinalizeStyle(charIndex);

        //    //            thisStyle = highlight.DeepCopy();
        //    //            thisStyle.Range[0] = charIndex;
        //    //            charIndex += columnWidths[column];
        //    //            thisStyle.Range[1] = charIndex;
        //    //            Styles.Add(thisStyle);

        //    //            thisStyle = background.DeepCopy();
        //    //            thisStyle.Range[0] = charIndex;
        //    //        }
        //    //        FinalizeStyle(Text.Length);
        //    //    }
        //    //}
        //    #endregion
        //}
        #endregion

        #region Mask
        //public class Mask : ConstantMaterial, ICloneable<Mask>
        //{
        //    //public string Category { get; set; }

        //    public MaskConfig Config { get; set; }

        //    Mask ICloneable<Mask>.DeepCopy()
        //    {
        //        var other = (Mask)DeepCopy();
        //        other.Config = Config.DeepCopy();
        //        return other;
        //    }
        //}

        //public List<HslItem> Hsl { get; set; }

        //public class HslItem : ConstantMaterial
        //{
        //}

        //[JsonPropertyName("common_mask")]
        //public List<Mask> Masks { get; set; }
        #endregion
    }
}
