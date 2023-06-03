using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    [CustomEditor(typeof(SDToolAsset))]
    public abstract class SDToolAssetEditor : ExtendedEditor
    {
        Vector2 _scroll;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            ExtendedGUI.BeginAlignCenter();

            if (ExtendedGUI.Button("Open in SD Tool", 32, 120))
                OpenWindow();

            ExtendedGUI.EndAlignCenter();

            DrawInInspector();
        }

        protected abstract void OpenWindow();

        protected virtual void DrawInInspector() => DrawDefaultInspector();

        public void DrawInWindow()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            DrawInInspector();

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(2);
        }
    }
}