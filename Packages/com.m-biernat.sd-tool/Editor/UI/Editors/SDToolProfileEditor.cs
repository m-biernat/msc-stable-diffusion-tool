using SDTool.Profile;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(SDToolProfile))]
    public partial class SDToolProfileEditor : ExtendedEditor
    {
        SDToolProfile _profile;

        void OnEnable() => _profile = (SDToolProfile)target;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            ExtendedGUI.BeginAlignCenter();

            if (ExtendedGUI.Button("Open in SD Tool", 32, 120))
                SDToolEditorWindow.Open((SDToolProfile)target);

            ExtendedGUI.EndAlignCenter();
            ExtendedGUI.EndIndent();

            DrawInInspector();
        }

        public void DrawInInspector()
        {
            serializedObject.Update();

            PropertyField(nameof(_profile.Txt2Img), "Text to Image");

            EditorGUILayout.Space(16);

            PropertyField(nameof(_profile.ControlNet));

            EditorGUILayout.Space(16);

            PropertyField(nameof(_profile.RemoveBackground));

            serializedObject.ApplyModifiedProperties();
        }

        public void DrawInWindow()
        {
            DrawInInspector();

            EditorGUILayout.Space();

            GUILayout.FlexibleSpace();

            if(ExtendedGUI.Button("Generate", 32, 128))
            {
                Debug.Log("test");
            }

            EditorGUILayout.Space();
        }
    }
}