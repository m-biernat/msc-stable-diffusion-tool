using Newtonsoft.Json;
using SDWebUIAPIClient.Serialization;
using UnityEngine;

namespace SDWebUIAPIClient.Models
{
    public class ExtraBatchImagesResult
    {
        [JsonProperty("html_info")]
        public string HtmlInfo { get; private set; }

        [JsonProperty("images")]
        public string[] Images { get; private set; }
    }

    public class ExtraBatchImagesResultT2D : ExtraBatchImagesResult
    {
        [JsonProperty("images", ItemConverterType = typeof(Texture2DConverter))]
        public new Texture2D[] Images { get; private set; }
    }
}