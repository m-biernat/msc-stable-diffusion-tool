using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    public class ExtraSingleImageResult
    {
        [JsonProperty("html_info")]
        public string HtmlInfo { get; private set; }

        [JsonProperty("image"), JsonConverter(typeof(Texture2DConverter))]
        public Texture2D Image { get; private set; }
    }
}