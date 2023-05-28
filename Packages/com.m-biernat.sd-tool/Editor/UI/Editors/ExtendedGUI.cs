using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    public static class ExtendedGUI
    {
        public static bool Button(string label, float minHeight, float minWidth)
            => GUILayout.Button(label, GUILayout.MinHeight(minHeight), GUILayout.MinWidth(minWidth));

        public static void BeginAlignCenter()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
        }

        public static void EndAlignCenter()
        {
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        public static bool Foldout(bool state, string label)
            => EditorGUILayout.Foldout(state, label, true);

        public static void BeginIndent()
            => EditorGUI.indentLevel++;

        public static void EndIndent()
            => EditorGUI.indentLevel--;

        public static void WarningBox(string message)
            => EditorGUILayout.HelpBox(message, MessageType.Warning);

        public static int Toolbar(int selected, string[] labels, float minHeight) 
            => GUILayout.Toolbar(selected, labels, GUILayout.MinHeight(minHeight));

        public static void Separator()
            => EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        public static T ObjectField<T>(string label, T obj, bool allowSceneObjects = false) 
            where T : Object
            => EditorGUILayout.ObjectField(label, obj, typeof(T), allowSceneObjects) as T;

        public static string TextArea(string label, string value)
        {
            var style = new GUIStyle(EditorStyles.textArea);
            style.wordWrap = true;
            EditorGUILayout.PrefixLabel(label);
            return EditorGUILayout.TextArea(value, style);
        }
    }
}