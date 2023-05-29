using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    public class PreprocessEditorWindow : EditorWindow
    {
        static Texture2D _input;
        static Texture2D _result;

        public static void Open(Texture2D input, Texture2D result)
        {
            _input = input;
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
            _input = null;
            _result = null;
        }

        void OnGUI()
        {
            ExtendedGUI.BeginAlignCenter();

            ShowImage("Input", _input);

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