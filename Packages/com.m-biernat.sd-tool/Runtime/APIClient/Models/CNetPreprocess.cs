using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CNetPreprocess
    {
        [JsonProperty("controlnet_module")]
        public string Module { get; set; }

        [JsonProperty("controlnet_input_images")]
        public string[] InputImages { get; set; }

        [JsonProperty("controlnet_processor_res"), JsonConverter(typeof(IntConverter))]
        public int? ProcessorRes { get; set; }

        [JsonProperty("controlnet_threshold_a")]
        public float? TresholdA { get; set; }

        [JsonProperty("controlnet_threshold_b")]
        public float? TresholdB { get; set; }
    }

    public class CNetPreprocessT2D : CNetPreprocess
    {
        [JsonProperty("controlnet_input_images", ItemConverterType = typeof(Texture2DConverter))]
        public new Texture2D[] InputImages { get; set; }
    }
}