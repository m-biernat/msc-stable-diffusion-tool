using SDTool.Editor.UI;
using SDTool.Profile;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor
{
    public static class SDToolManager
    {
        public static SDToolProfile CreateProfile()
        {
            var assetPath = AssetDatabase.GenerateUniqueAssetPath(
                "Assets/New SDTool Profile.asset");

            var instance = ScriptableObject.CreateInstance<SDToolProfile>();
            AssetDatabase.CreateAsset(instance, assetPath);

            return AssetDatabase.LoadAssetAtPath<SDToolProfile>(assetPath);
        }

        public static SDToolProfile CloneProfile(SDToolProfile profile)
        {
            if (!profile) return null;

            var assetPath = AssetDatabase.GetAssetPath(profile);
            var clonePath = AssetDatabase.GenerateUniqueAssetPath(assetPath);

            if (!AssetDatabase.CopyAsset(assetPath, clonePath))
            {
                Debug.LogWarning($"Failed to copy {profile.name}");
                return profile;
            }

            return AssetDatabase.LoadAssetAtPath<SDToolProfile>(clonePath);
        }

        public static async void Process(SDToolProfile profile)
        {
            var result = await DataProcessor.ProcessAsync(profile);

            ResultEditorWindow.Open(profile, result);
        }

        public static async void Preprocess(SDToolProfile profile)
        {
            var result = await DataProcessor.PreprocessAsync(profile);

            PreprocessEditorWindow.Open(profile.ControlNet.InputImage, result);
        }

        public static void SaveAsSprite(Texture2D image, SDToolProfile profile)
        {
            var rect = new Rect(0, 0, image.width, image.height);
            var pivot = new Vector2(.5f, .5f);
            var sprite = Sprite.Create(image, rect, pivot);
            
            var path = AssetDatabase.GetAssetPath(profile);
            path = path.Substring(0, path.Length - 6);
            var assetPath = AssetDatabase.GenerateUniqueAssetPath($"IMG {path}.png");

            AssetDatabase.CreateAsset(sprite, assetPath);
        }
    }
}