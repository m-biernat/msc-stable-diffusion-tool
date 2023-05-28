using UnityEditor;

namespace SDTool.Editor
{
    public static class ExtensionMethods
    {
        public static SerializedProperty FindField(this SerializedObject serializedObject,
                                                   string fieldName)
        {
            return serializedObject.FindProperty($"<{fieldName}>k__BackingField");
        }

        public static SerializedProperty FindFieldRelative(this SerializedProperty property,
                                                           string fieldName)
        {
            return property.FindPropertyRelative($"<{fieldName}>k__BackingField");
        }

        public static SerializedProperty FindFieldRelative(this SerializedObject serializedObject,
                                                           string parentName, string fieldName)
        {
            return serializedObject.FindField(parentName).FindFieldRelative(fieldName);
        }
    }
}