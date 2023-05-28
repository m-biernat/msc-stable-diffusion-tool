using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    public class Txt2ImgResult
    {
        [JsonProperty("images", ItemConverterType = typeof(Texture2DConverter))]
        public Texture2D[] Images { get; private set; }

        [JsonProperty("parameters")]
        public Txt2Img Parameters { get; private set; }

        [JsonProperty("info")]
        public string Info { get; private set; }
    }
}