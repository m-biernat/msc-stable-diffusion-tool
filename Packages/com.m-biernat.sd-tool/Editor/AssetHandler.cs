using SDTool.Editor.UI;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.Callbacks;

namespace SDTool.Editor
{
    static class AssetHandler
    {
        [OnOpenAsset()]
        static bool OpenInEditorWindow(int instanceID, int line)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceID) as SDToolAsset;

            if (obj)
            {
                var profile = obj as ProfileData;

                if (profile)
                {
                    SDToolEditorWindow.Open(profile);
                    return true;
                }

                var autorun = obj as BatchData;

                if (autorun)
                {
                    SDToolEditorWindow.Open(autorun);
                    return true;
                }
            }

            return false;
        }
    }
}