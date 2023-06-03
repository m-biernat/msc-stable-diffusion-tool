using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    public class PreprocessEditorWindow : EditorWindow
    {
        static ProfileData _profile;
        static Texture2D _result;

        public static void Open(ProfileData profile, Texture2D result)
        {
            _profile = profile;
            _result = result;

            var window = 
                GetWindow<PreprocessEditorWindow>(
                    true, "ControlNet Preprocess Result", false);

            window.maxSize = new Vector2(576, 320);
            window.minSize = window.maxSize;
        }

        void OnEnable()
        {
            if (_result == null)
                Close();
        }

        void OnDisable()
        {
            _profile = null;
            _result = null;
        }

        void OnGUI()
        {
            ExtendedGUI.BeginAlignCenter();

            ShowImage("Input", _profile.ControlNet.InputImage);

            EditorGUILayout.Space(16);

            ShowImage("Result", _result);
            
            ExtendedGUI.EndAlignCenter();
        }

        void ShowImage(string label, Texture2D image)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space(16);

            GUILayout.Label(label);
            GUILayout.Label(image, 
                            GUILayout.MaxWidth(256), 
                            GUILayout.MaxHeight(256));

            EditorGUILayout.EndVertical();
        }
    }
}