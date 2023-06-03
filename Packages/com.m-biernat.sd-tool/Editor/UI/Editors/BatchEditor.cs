using UnityEditor;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(BatchData))]
    public class BatchEditor : SDToolAssetEditor
    {
        protected override void OpenWindow() 
            => SDToolEditorWindow.Open((BatchData)target);

        protected override void DrawInInspector()
        {
            serializedObject.Update();

            SerializedProperty prop = serializedObject.GetIterator();

            if (prop.NextVisible(true))
            {
                do
                {
                    if (prop.name == "m_Script")
                        continue;

                    EditorGUILayout.PropertyField(serializedObject.FindProperty(prop.name), true);
                }
                while (prop.NextVisible(false));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}