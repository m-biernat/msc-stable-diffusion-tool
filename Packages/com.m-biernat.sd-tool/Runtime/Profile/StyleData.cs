using SDWebUIAPIClient.Models;
using UnityEngine;

namespace SDTool.Profile
{
    [CreateAssetMenu(fileName = "SDTool Style", menuName = "SD Tool/Style")]
    public class StyleData : ScriptableObject
    {
        [field: SerializeField, TextArea(1, 4)]
        public string Prompt { get; private set; } = "";

        [field: SerializeField, TextArea(1, 4), Space()]
        public string NegativePrompt { get; private set; } = "";

        public void Apply(Txt2Img payload)
        {
            if (Prompt != "")
                payload.Prompt = $"{payload.Prompt}, {Prompt}";

            if (NegativePrompt != "")
                payload.NegativePrompt = $"{payload.NegativePrompt}, {NegativePrompt}";
        }
    }
}