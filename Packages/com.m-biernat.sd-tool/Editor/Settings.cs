using SDWebUIAPIClient;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor
{
    public class Settings : ScriptableSingleton<Settings>
    {
        [field: SerializeField]
        public string ServerAddress { get; private set; }

        void OnEnable() => ServerAddress = Client.LoadAddress();

        public static void MakeEditable()
        {
            if (instance.hideFlags.HasFlag(HideFlags.NotEditable))
                instance.hideFlags &= ~HideFlags.NotEditable;
        }

        public static void ChangeAddress()
            => Client.ChangeAddress(instance.ServerAddress);

        public static void ResetAddress()
        {
            Client.ResetAddress();
            instance.ServerAddress = Client.LoadAddress();
        }
    }
}