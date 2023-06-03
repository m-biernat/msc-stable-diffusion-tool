using UnityEditor;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(ProfileData))]
    public class ProfileEditor : SDToolAssetEditor
    {
        bool _foldout = true;

        protected override void OpenWindow()
            => SDToolEditorWindow.Open((ProfileData)target);

        protected override void DrawInInspector()
        {
            var profile = (ProfileData)target;

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
    }
}