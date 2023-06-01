using SDWebUIAPIClient;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor
{
    public class Settings : ScriptableSingleton<Settings>
    {
        [field: SerializeField]
        public string ServerAddress { get; private set; }

        void OnEnable()
        {
            ServerAddress = Client.LoadAddress();
            hideFlags &= ~HideFlags.NotEditable;
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