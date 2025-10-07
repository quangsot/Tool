using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapCutTool.Service
{
    public interface IDraftService
    {
        bool InsertAnimation();
        bool InsertEffect();
    }
    public class DraftService : IDraftService
    {
        const string projectName = "clip_test";
        public bool InsertAnimation()
        {
            try
            {
                var root = CommonUtil.GetJsonContent(projectName);

                var segments = (JArray?)root.SelectToken("tracks[0].segments") ?? [];
                var materialAnimations = (JArray?)root.SelectToken("materials.material_animations");
                materialAnimations?.Clear();

                List<string> listAnimation = Data.Animations;
                int animationIndex = 0;
                foreach (var segment in segments)
                {
                    if (animationIndex == listAnimation.Count) animationIndex = 0;
                    while (animationIndex < listAnimation.Count)
                    {
                        var newAnimation = JObject.Parse(listAnimation[animationIndex]);
                        materialAnimations?.Add(newAnimation);

                        var materialRef = (JArray?)segment.SelectToken("extra_material_refs");
                        materialRef?.Add(newAnimation["id"]);

                        animationIndex++;
                        break;
                    }
                }

                CommonUtil.SaveJsonContent(root, projectName);
                return true;
            
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool InsertEffect()
        {
            try
            {
                var root = CommonUtil.GetJsonContent(projectName);

                // 1.Clear Effects list
                CommonUtil.ClearEffectList(root);

                // 2. Create Effects Segment
                var effects = Data.Effects;
                // Get list video
                var videos = CommonUtil.GetVideoSegments(root);

                foreach (var video in videos)
                {
                    // create effect
                    var effectSegment = new EffectSegment()
                    {
                        Target = new TimeRange()
                        {
                            Start = video.Target.Start
                        }
                    };

                    int effectIndex = videos.Count / effects.Count;
                    var effectSegmentObject = effectSegment.GenerateEffect(effects[effectIndex]);

                    // add effect to material
                    CommonUtil.AddEffectToMaterial(root, JObject.Parse(effects[effectIndex]));

                    // add effectSegment to track effect
                    CommonUtil.AddEffectToSegment(root, effectSegmentObject);
                }

                // 3. Save
                CommonUtil.SaveJsonContent(root, projectName);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }

}
