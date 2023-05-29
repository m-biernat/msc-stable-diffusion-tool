using SDTool.Profile;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(SDToolProfile))]
    public class SDToolProfileEditor : ExtendedEditor
    {
        Vector2 _scroll;

        bool _foldout = true;

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
            var profile = (SDToolProfile)target;

            serializedObject.Update();

            PropertyField(nameof(profile.Txt2Img), "Text to Image");

            EditorGUILayout.Space(16);

            PropertyField(nameof(profile.ControlNet));

            EditorGUILayout.Space(16);

            PropertyField(nameof(profile.RemBgModel));

            EditorGUILayout.Space(16);

            _foldout = EditorGUILayout.Foldout(_foldout, "Settings");

            ExtendedGUI.BeginIndent();
            if (_foldout)
            {
                PropertyField(nameof(profile.UseControlNet));
                PropertyField(nameof(profile.UseRemBg));

                EditorGUILayout.Space();

                PropertyField(nameof(profile.AutoSaveImages));
            }
            ExtendedGUI.EndIndent();

            EditorGUILayout.Space(16);

            serializedObject.ApplyModifiedProperties();
        }

        public void DrawInWindow()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);
            
            DrawInInspector();

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(2);
        }
    }
}