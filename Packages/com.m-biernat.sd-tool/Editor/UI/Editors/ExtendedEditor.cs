using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    public class ExtendedEditor : UnityEditor.Editor
    {
        public SerializedProperty FindField(string fieldName)
            => serializedObject.FindField(fieldName);

        public SerializedProperty FindField(string fieldName, string relativeFieldName)
            => FindField(fieldName).FindFieldRelative(relativeFieldName);

        public bool PropertyField(SerializedProperty property)
            => EditorGUILayout.PropertyField(property);

        public bool PropertyField(SerializedProperty property, string label)
            => EditorGUILayout.PropertyField(property, new GUIContent(label));

        public bool PropertyField(string fieldName)
            => PropertyField(FindField(fieldName));

        public bool PropertyField(string fieldName, string label)
            => PropertyField(FindField(fieldName), label);
    }
}