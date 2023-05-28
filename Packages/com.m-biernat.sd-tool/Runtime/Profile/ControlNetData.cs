using SDTool.APIClient.Models;
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
            "none", "canny"
        })]
        public string Preprocessor { get; private set; }

        [field: SerializeField, Dropdown(new string[]
        {
            "None", "control_v11p_sd15_canny [d14c016b]"
        })]
        public string Model { get; private set; }

        [field: SerializeField, Range(0, 2), Space()]
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
    }
}