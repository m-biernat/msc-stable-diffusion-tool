using UnityEngine;
using UnityEditor;

namespace SDTool.Editor
{
    [CustomPropertyDrawer(typeof(DropdownAttribute))]
    public class DropdownDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DropdownAttribute dropdown = attribute as DropdownAttribute;

            if (property.propertyType == SerializedPropertyType.String)
            {
                dropdown.IndexFromValue(property.stringValue);
                dropdown.index = 
                    EditorGUI.Popup(position, label.text, dropdown.index, dropdown.values);
                property.stringValue = dropdown.values[dropdown.index];
            }
            else
                EditorGUI.PropertyField(position, property);
        }
    }
}