using UnityEditor;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(Settings))]
    public class SettingsEditor : ExtendedEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var instance = Settings.instance;

            PropertyField(nameof(instance.ServerAddress));

            EditorGUILayout.Space();

            ServerButtons();

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

        void ServerButtons()
        {
            ExtendedGUI.BeginAlignCenter();

            if (ExtendedGUI.Button("Save Address", 32, 120))
                Settings.ChangeAddress();

            EditorGUILayout.Space();

            if (ExtendedGUI.Button("Reset to Default", 32, 120))
                Settings.ResetAddress();

            ExtendedGUI.EndAlignCenter();
        }
    }
}