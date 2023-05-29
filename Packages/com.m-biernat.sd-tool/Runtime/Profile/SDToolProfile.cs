using UnityEngine;

namespace SDTool.Profile
{
    [CreateAssetMenu(fileName = "SDTool Profile", menuName = "SD Tool/Profile")]
    public class SDToolProfile : ScriptableObject
    {
        [field: SerializeField]
        public Txt2ImgData Txt2Img { get; private set; }

        [field: SerializeField]
        public ControlNetData ControlNet { get; private set; }

        [field: SerializeField, Dropdown(new string[]
        {
            "u2net", "u2netp", "u2net_human_seg",
            "u2net_cloth_seg", "silueta"
        })]
        public string RemBgModel { get; private set; } = "u2net";

        [field: SerializeField]
        public bool UseControlNet { get; private set; }

        [field: SerializeField]
        public bool UseRemBg { get; private set; }

        [field: SerializeField]
        public bool AutoSaveImages { get; private set; }
    }
}