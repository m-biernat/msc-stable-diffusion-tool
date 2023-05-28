using Newtonsoft.Json;
using SDTool.APIClient.Serialization;
using UnityEngine;

namespace SDTool.APIClient.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Txt2Img
    {
        [JsonProperty("enable_hr")]
        public bool? EnableHr { get; set; }

        [JsonProperty("denoising_strength")]
        public float? DenoisingStrength { get; set; }

        [JsonProperty("firstphase_width"), JsonConverter(typeof(IntConverter))]
        public int? FirstphaseWidth { get; set; }

        [JsonProperty("firstphase_height"), JsonConverter(typeof(IntConverter))]
        public int? FirstphaseHeight { get; set; }

        [JsonProperty("hr_scale")]
        public float? HrScale { get; set; }

        [JsonProperty("hr_upscaler")]
        public string HrUpscaler { get; set; }

        [JsonProperty("hr_second_pass_steps"), JsonConverter(typeof(IntConverter))]
        public int? HrSecondPassSteps { get; set; }

        [JsonProperty("hr_resize_x"), JsonConverter(typeof(IntConverter))]
        public int? HrResizeX { get; set; }

        [JsonProperty("hr_resize_y"), JsonConverter(typeof(IntConverter))]
        public int? HrResizeY { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("styles")]
        public string[] Styles { get; set; }

        [JsonProperty("seed"), JsonConverter(typeof(IntConverter))]
        public int? Seed { get; set; }

        [JsonProperty("subseed"), JsonConverter(typeof(IntConverter))]
        public int? Subseed { get; set; }

        [JsonProperty("subseed_strength")]
        public float? SubseedStrength { get; set; }

        [JsonProperty("seed_resize_from_h"), JsonConverter(typeof(IntConverter))]
        public int? SeedResizeFromH { get; set; }

        [JsonProperty("seed_resize_from_w"), JsonConverter(typeof(IntConverter))]
        public int? SeedResizeFromW { get; set; }

        [JsonProperty("sampler_name")]
        public string SamplerName { get; set; }

        [JsonProperty("batch_size"), JsonConverter(typeof(IntConverter))]
        public int? BatchSize { get; set; }

        [JsonProperty("n_iter"), JsonConverter(typeof(IntConverter))]
        public int? NIter { get; set; }

        [JsonProperty("steps"), JsonConverter(typeof(IntConverter))]
        public int? Steps { get; set; }

        [JsonProperty("cfg_scale")]
        public float? CfgScale { get; set; }

        [JsonProperty("width"), JsonConverter(typeof(IntConverter))]
        public int? Width { get; set; }

        [JsonProperty("height"), JsonConverter(typeof(IntConverter))]
        public int? Height { get; set; }

        [JsonProperty("restore_faces")]
        public bool? RestoreFaces { get; set; }

        [JsonProperty("tiling")]
        public bool? Tiling { get; set; }

        [JsonProperty("do_not_save_samples")]
        public bool? DoNotSaveSamples { get; set; }

        [JsonProperty("do_not_save_grid")]
        public bool? DoNotSaveGrid { get; set; }

        [JsonProperty("negative_prompt")]
        public string NegativePrompt { get; set; }

        [JsonProperty("eta")]
        public float? Eta { get; set; }

        [JsonProperty("s_churn")]
        public float? SChurn { get; set; }

        [JsonProperty("s_tmax")]
        public float? STmax { get; set; }

        [JsonProperty("s_tmin")]
        public float? STmin { get; set; }

        [JsonProperty("s_noise")]
        public float? SNoise { get; set; }

        [JsonProperty("override_settings")]
        public object OverrideSettings { get; set; }

        [JsonProperty("override_settings_restore_afterwards")]
        public bool? OverrideSettingsRestoreAfterwards { get; set; }

        [JsonProperty("script_args")]
        public object[] ScriptArgs { get; set; }

        [JsonProperty("sampler_index")]
        public string SamplerIndex { get; set; }

        [JsonProperty("script_name")]
        public string ScriptName { get; set; }

        [JsonProperty("send_images")]
        public bool? SendImages { get; set; }

        [JsonProperty("save_images")]
        public bool? SaveImages { get; set; }

        [JsonProperty("alwayson_scripts")]
        public object AlwaysOnScripts { get; set; }
    }
}