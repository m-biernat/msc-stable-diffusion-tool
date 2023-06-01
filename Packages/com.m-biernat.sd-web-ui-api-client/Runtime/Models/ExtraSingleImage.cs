using Newtonsoft.Json;
using SDWebUIAPIClient.Serialization;
using UnityEngine;

namespace SDWebUIAPIClient.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExtraSingleImage
    {
        [JsonProperty("resize_mode")]
        public ResizeMode? ResizeMode { get; set; }

        [JsonProperty("show_extras_results")]
        public bool? ShowExtrasResults { get; set; }

        [JsonProperty("gfpgan_visibility")]
        public float? GfpganVisibility { get; set; }

        [JsonProperty("codeformer_visibility")]
        public float? CodeformerVisibility { get; set; }

        [JsonProperty("codeformer_weight")]
        public float? CodeformerWeight { get; set; }

        [JsonProperty("upscaling_resize")]
        public float? UpscalingResize { get; set; }

        [JsonProperty("upscaling_resize_w"), JsonConverter(typeof(IntConverter))]
        public int? UpscalingResizeW { get; set; }

        [JsonProperty("upscaling_resize_h"), JsonConverter(typeof(IntConverter))]
        public int? UpscalingResizeH { get; set; }

        [JsonProperty("upscaling_crop")]
        public bool? UpscalingCrop { get; set; }

        [JsonProperty("upscaler_1")]
        public string Upscaler1 { get; set; }

        [JsonProperty("upscaler_2")]
        public string Upscaler2 { get; set; }

        [JsonProperty("extras_upscaler_2_visibility")]
        public float? ExtrasUpscaler2Visibility { get; set; }

        [JsonProperty("upscale_first")]
        public bool? UpscaleFirst { get; set; }

        [JsonProperty("rembg_model")]
        public string RemBgModel { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public enum ResizeMode : int { A, B }

    public class ExtraSingleImageT2D : ExtraSingleImage
    {
        [JsonProperty("image"), JsonConverter(typeof(Texture2DConverter))]
        public new Texture2D Image { get; set; }
    }
}