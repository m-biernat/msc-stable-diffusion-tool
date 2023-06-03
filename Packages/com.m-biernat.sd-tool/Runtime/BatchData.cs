using SDTool.Profile;
using UnityEngine;

namespace SDTool
{
    [CreateAssetMenu(fileName = "SDTool Batch", menuName = "SD Tool/Batch")]
    public class BatchData : SDToolAsset
    {
        [field: SerializeField]
        public ProfileData[] Profiles { get; private set; }

        [field: SerializeField, Space()]
        public StyleData Style { get; private set; }

        [field: SerializeField, Space()]
        public bool OverrideBatching { get; private set; } = true;

        [field: SerializeField, Range(1, 100)]
        public int BatchCount { get; private set; } = 1;

        [field: SerializeField, Range(1, 8)]
        public int SingleBatchSize { get; private set; } = 1;

        public ProfileData[] PrepareProfiles()
        {
            if (!(Style && OverrideBatching))
                return Profiles;

            var profiles = new ProfileData[Profiles.Length];

            for (int i = 0; i < Profiles.Length; i++)
            {
                profiles[i] = Instantiate(Profiles[i]);

                if (Style)
                    profiles[i].Txt2Img.OverrideStyle(Style);

                if (OverrideBatching)
                    profiles[i].Txt2Img.OverrideBatching(BatchCount, SingleBatchSize);
            }

            return profiles;
        }
    }
}