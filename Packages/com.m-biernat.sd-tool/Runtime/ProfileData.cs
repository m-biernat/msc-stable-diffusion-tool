using SDTool.Profile;
using UnityEngine;

namespace SDTool
{
    [CreateAssetMenu(fileName = "SDTool Profile", menuName = "SD Tool/Profile")]
    public class ProfileData : SDToolAsset
    {
        ProfileData _original;

        public ProfileData Original 
        { get => _original == null ? this : _original; }

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

        public void SetOriginal(ProfileData profile)
        {
            if (Original != profile)
                _original = profile;
        }
    }
}