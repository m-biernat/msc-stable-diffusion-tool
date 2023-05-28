using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(Settings))]
    public class SettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var instance = Settings.instance;

            //UIPropertyField(nameof(instance.ServerAddress));
            EditorGUILayout.PropertyField(serializedObject.FindField(nameof(Settings.instance.ServerAddress)));

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