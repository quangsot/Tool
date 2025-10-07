using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Service
{
    public static class CommonUtil
    {
        const string projectFilePath = "C:\\Users\\ADMIN\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
        const string outputVideoPath = "C:\\Users\\ADMIN\\AppData\\Local\\CapCut\\Videos\\";
        const string jsonFilenName = "draft_content.json";

        const string segmentVideoPathJson = "tracks[0].segments";
        const string segmentEffectPathJson = "tracks[1].segments";

        #region File Json
        public static JObject GetJsonContent(string projectName)
        {
            string jsonFilePath = Path.Combine(projectFilePath, projectName, jsonFilenName);
            var json = File.ReadAllText(jsonFilePath);
            var root = JObject.Parse(json);
            return root;
        }

        public static void SaveJsonContent(JObject json, string projectName)
        {
            string jsonFilePath = Path.Combine(projectFilePath, projectName, jsonFilenName);
            File.WriteAllText(jsonFilePath, json.ToString());
        }
        #endregion

        #region Effect
        public static void ClearEffectList(JObject root)
        {
            var effects = root.SelectTokens("materials.video_effects").ToList();

            effects.Clear();
        }

        public static void AddEffectToMaterial(JObject root, JObject effect)
        {
            ((JArray)root.SelectTokens("materials.video_effects")).ToList().Add(effect);
        }

        public static void AddEffectToSegment(JObject root, JObject effect)
        {
            var effectSegments = (JArray)root.SelectTokens(segmentEffectPathJson);
            effectSegments.Add(effectSegments);
        }
        #endregion

        #region Video
        /// <summary>
        /// Get List VideoSegment
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<VideoSegment> GetVideoSegments(JObject root)
        {
            var videoSegments = new List<VideoSegment>();
            var videos = root.SelectTokens(segmentVideoPathJson).ToList();

            foreach (var video in videos)
            {
                double duration;
                double.TryParse(video.SelectToken("source_timerange.duration")?.ToString(), out duration);

                var sourceTimeRange = new TimeRange()
                {
                    Duration = duration,
                    Start = video["source_timerange.start"].Value<double>()
                };

                var targetTimeRange = new TimeRange()
                {
                    Duration = video["target_timerange.duration"].Value<double>(),
                    Start = video["target_timerange.start"].Value<double>()
                };

                var videoSegment = new VideoSegment()
                {
                    Id = video["id"]?.ToString() ?? string.Empty,
                    MaterialId = video["material_id"]?.ToString() ?? string.Empty,
                    Source = sourceTimeRange,
                    Target = targetTimeRange
                };

                videoSegments.Add(videoSegment);
            }
            return videoSegments;
        }
        #endregion

    }
}
