using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    public class CNetPreprocessResult
    {
        [JsonProperty("images")]
        public string[] Images { get; private set; }

        [JsonProperty("info")]
        public string Info { get; private set; }
    }

    public class CNetPreprocessResultT2D : CNetPreprocessResult
    {
        [JsonProperty("images", ItemConverterType = typeof(Texture2DConverter))]
        public new Texture2D[] Images { get; private set; }
    }
}