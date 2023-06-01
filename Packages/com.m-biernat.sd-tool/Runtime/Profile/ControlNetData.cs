using SDWebUIAPIClient.Models;
using System;
using UnityEngine;

namespace SDTool.Profile
{
    [Serializable]
    public class ControlNetData
    {
        [field: SerializeField]
        public Texture2D InputImage { get; private set; }

        [field: SerializeField, Space(), Dropdown(new string[]
        {
            "canny"
        })]
        public string Preprocessor { get; private set; } = "canny";

        [field: SerializeField, Dropdown(new string[]
        {
            "control_v11p_sd15_canny [d14c016b]"
        })]
        public string Model { get; private set; } = "control_v11p_sd15_canny [d14c016b]";

        [field: SerializeField, Range(0, 2), Space(14)]
        public float ControlWeight { get; private set; } = 1;

        [field: SerializeField, Range(0, 1)]
        public float StartingControlStep { get; private set; } = 0;

        [field: SerializeField, Range(0, 1)]
        public float EndingControlStep { get; private set; } = 1;

        [field: SerializeField, Range(64, 2048), Space()]
        public int PreprocessorResolution { get; private set; } = 512;

        [field: SerializeField, Range(1, 255), Space()]
        public int TresholdA { get; private set; } = 100;

        [field: SerializeField, Range(1, 255)]
        public int TresholdB { get; private set; } = 200;

        [field: SerializeField, Space()]
        public CNetControlMode ControlMode { get; private set; } = CNetControlMode.Balanced;

        [field: SerializeField]
        public CNetResizeMode ResizeMode { get; private set; } = CNetResizeMode.Envelope;

        [field: SerializeField, Space()]
        public bool PixelPerfect { get; private set; }

        [field: SerializeField]
        public bool LowVRAM { get; private set; }

        public CNetPreprocessT2D GetPreprocessPayload()
        {
            return new CNetPreprocessT2D()
            {
                InputImages = new Texture2D[] { InputImage },
                Module = Preprocessor,
                ProcessorRes = PreprocessorResolution,
                TresholdA = TresholdA,
                TresholdB = TresholdB
            };
        }

        public CNetUnitT2D GetPayload()
        {
            return new CNetUnitT2D()
            {
                InputImage = InputImage,
                Module = Preprocessor,
                Model = Model,
                Weight = ControlWeight,
                GuidanceStart = StartingControlStep,
                GuidanceEnd = EndingControlStep,
                ProcessorRes = PreprocessorResolution,
                TresholdA = TresholdA,
                TresholdB = TresholdB,
                ControlMode = ControlMode,
                ResizeMode = ResizeMode,
                LowVRAM = LowVRAM
            };
        }
    }
}