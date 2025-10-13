using CapCutTool.Core;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapCutTool.Core.Model.Materials;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapCutTool.Service
{
    public interface IDraftService
    {
        Task<bool> InsertAnimation();
        Task<bool> InsertEffect();
    }
    public class DraftService : IDraftService
    {
        const string projectName = "clip_test";

        public async Task<bool> InsertAnimation()
        {
            const string projectFilePath = "C:\\Users\\ADMIN\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
            string jsonFilePath = Path.Combine(projectFilePath, "clip_test_1");
            //Set current directory to the folder of CapCut project, for example: %userprofile%\AppData\Local\CapCut\User Data\Projects\com.lveditor.draft\Test
            var ctx = new Context(jsonFilePath);
            var project = await ctx.GetProjectAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Để tự động map kể cả khi JSON viết kiểu snake_case
            };

            project.Materials.MaterialAnimations.RemoveAt(0);

            //var animation = JsonSerializer.Deserialize<MaterialAnimation>(Data.Animations[1], options);

            //if (animation != null)
            //{
            //    project.Materials.MaterialAnimations.Add(animation);
            //}

            await ctx.SaveChangesAsync();
            return true;
        }

        //public async Task<bool> InsertAnimation()
        //{
        //    try
        //    {
        //        var root = await CommonUtil.GetJsonContent(projectName);

        //        var segments = (JArray?)root.SelectToken("tracks[0].segments") ?? [];
        //        var materialAnimations = (JArray?)root.SelectToken("materials.material_animations");
        //        materialAnimations?.Clear();

        //        List<string> listAnimation = Data.Animations;
        //        int animationIndex = 0;
        //        foreach (var segment in segments)
        //        {
        //            if (animationIndex == listAnimation.Count) animationIndex = 0;
        //            while (animationIndex < listAnimation.Count)
        //            {
        //                var newAnimation = JObject.Parse(listAnimation[animationIndex]);
        //                materialAnimations?.Add(newAnimation);

        //                var materialRef = (JArray?)segment.SelectToken("extra_material_refs");
        //                materialRef?.Add(newAnimation["id"]);

        //                animationIndex++;
        //                break;
        //            }
        //        }

        //        CommonUtil.SaveJsonContent(root, projectName);
        //        return true;

        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        public async Task<bool> InsertEffect()
        {
            return await Task.FromResult(true);
            //try
            //{
            //    var root = await CommonUtil.GetJsonContent(projectName);

            //    // 1.Clear Effects list
            //    CommonUtil.ClearEffectList(root);

            //    // 2. Create Effects Segment
            //    var effects = Data.Effects;

            //    // add effect to material
            //    CommonUtil.AddEffectToMaterial(root, effects);

            //    // Get list video
            //    var videos = CommonUtil.GetVideoSegments(root);

            //    foreach (var video in videos)
            //    {
            //        // create effect
            //        var effectSegment = new EffectSegment()
            //        {
            //            Target = new TimeRange()
            //            {
            //                Start = video.Target.Start
            //            }
            //        };

            //        int effectIndex = videos.IndexOf(video) % effects.Count;
            //        var effectSegmentObject = effectSegment.GenerateEffect(effects[effectIndex]);

            //        // add effectSegment to track effect
            //        CommonUtil.AddEffectToSegment(root, effectSegmentObject);
            //    }

            //    // 3. Save
            //    CommonUtil.SaveJsonContent(root, projectName);

            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

        }
    }
}
