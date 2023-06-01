using Newtonsoft.Json;
using SDWebUIAPIClient.Serialization;
using UnityEngine;

namespace SDWebUIAPIClient.Models
{
    public class Txt2ImgResult
    {
        [JsonProperty("images")]
        public string[] Images { get; private set; }

        [JsonProperty("parameters")]
        public Txt2Img Parameters { get; private set; }

        [JsonProperty("info")]
        public string Info { get; private set; }
    }

    public class Txt2ImgResultT2D : Txt2ImgResult
    {
        [JsonProperty("images", ItemConverterType = typeof(Texture2DConverter))]
        public new Texture2D[] Images { get; private set; }
    }
}