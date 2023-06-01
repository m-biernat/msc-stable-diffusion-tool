using SDWebUIAPIClient.Models;
using System;
using UnityEngine;

namespace SDTool.Profile
{
    [Serializable]
    public class Txt2ImgData
    {
        [field: SerializeField, TextArea(1, 4)]
        public string Prompt { get; private set; } = "";

        [field: SerializeField, TextArea(1, 4), Space()]
        public string NegativePrompt { get; private set; } = "";

        [field: SerializeField, Space()]
        public SDToolStyle Style { get; private set; }

        [field: SerializeField, Space(14), Dropdown(new string[] 
        { 
            "Euler a", "Euler", "LMS", "Heun", "DPM2", "DPM2 a", 
            "DPM++ 2S a", "DPM++ 2M", "DPM++ SDE", "DPM fast",
            "DPM adaptive", "LMS Karras", "DPM2 Karras",
            "DPM++ 2S a Karras", "DPM++ 2M Karras", "DPM++ SDE Karras",
            "DDIM", "PLMS", "UniPC"
        })]
        public string Sampler { get; private set; } = "Euler a";

        [field: SerializeField, Range(1, 150)]
        public int Steps { get; private set; } = 10;

        [field: SerializeField, Range(1, 30)]
        public float CfgScale { get; private set; } = 7.0f;

        [field: SerializeField, Range(64, 2048), Space()]
        public int Width { get; private set; } = 512;

        [field: SerializeField, Range(64, 2048)]
        public int Height { get; private set; } = 512;

        [field: SerializeField, Range(1, 100), Space()]
        public int BatchCount { get; private set; } = 1;

        [field: SerializeField, Range(1, 8)]
        public int SingleBatchSize { get; private set; } = 1;

        [field: SerializeField, Range(-1, 999999), Space()]
        public int Seed { get; private set; } = -1;
        
        [field: SerializeField, Space()]
        public bool Tiling { get; private set; } = false;

        public Txt2Img GetPayload()
        {
            var payload = new Txt2Img()
            {
                Prompt = Prompt,
                NegativePrompt = NegativePrompt,
                SamplerName = Sampler,
                Steps = Steps,
                CfgScale = CfgScale,
                Width = Width,
                Height = Height,
                NIter = BatchCount,
                BatchSize = SingleBatchSize,
                Seed = Seed,
                Tiling = Tiling
            };

            if (Style)
                Style.Apply(payload);

            return payload;
        }
    }
}