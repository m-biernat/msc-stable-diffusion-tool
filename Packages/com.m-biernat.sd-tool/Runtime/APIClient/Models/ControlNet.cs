using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ControlNet
    {
        [JsonProperty("input_image"), JsonConverter(typeof(Texture2DConverter))]
        public Texture2D InputImage { get; set; }

        [JsonProperty("mask"), JsonConverter(typeof(Texture2DConverter))]
        public Texture2D Mask { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("weight")]
        public float? Weight { get; set; }

        [JsonProperty("resize_mode")]
        public ResizeMode? ResizeMode { get; set; }

        [JsonProperty("lowvram")]
        public bool? LowVRAM { get; set; }

        [JsonProperty("processor_res"), JsonConverter(typeof(IntConverter))]
        public int? ProcessorRes { get; set; }

        [JsonProperty("treshold_a")]
        public float? TresholdA { get; set; }

        [JsonProperty("treshold_b")]
        public float? TresholdB { get; set; }

        [JsonProperty("guidance_start")]
        public float? GuidanceStart { get; set; }

        [JsonProperty("guidance_end")]
        public float? GuidanceEnd { get; set; }

        [JsonProperty("control_mode")]
        public CNetControlMode? ControlMode { get; set; }

        [JsonProperty("pixel_perfect")]
        public bool? PixelPerfect { get; set; }
    }

    public enum CNetResizeMode : int { JustResize, ScaleToFit, Envelope }

    public enum CNetControlMode : int { Balanced, Prompt, ControlNet }
}