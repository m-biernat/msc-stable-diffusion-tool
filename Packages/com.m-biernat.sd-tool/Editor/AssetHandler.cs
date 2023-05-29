using SDTool.Editor.UI;
using SDTool.Profile;
using UnityEditor;
using UnityEditor.Callbacks;

namespace SDTool.Editor
{
    static class AssetHandler
    {
        [OnOpenAsset()]
        static bool OpenInEditorWindow(int instanceID, int line)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceID) as SDToolProfile;

            if (obj)
            {
                SDToolEditorWindow.Open(obj);
                return true;
            }

            return false;
        }
    }
}