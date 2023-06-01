using SDTool.Profile;
using System;
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

        public static async void Interrupt() => await DataProcessor.Interrupt();

        public static async void Preprocess(SDToolProfile profile,
                                            Action<SDToolProfile, Texture2D> callback)
        {
            var result = await DataProcessor.PreprocessAsync(profile);

            callback.Invoke(profile, result);
        }

        public static async void Process(SDToolProfile profile, 
                                         Action<SDToolProfile, Texture2D[]> callback)
        {
            var result = await DataProcessor.ProcessAsync(profile);

            if (profile.AutoSaveImages)
                SaveImages(profile, result);
            else
                callback.Invoke(profile, result);
        }    

        public static void SaveImages(SDToolProfile profile, Texture2D[] images)
        {
            var path = GetPath(profile);

            foreach (var image in images)
                SaveImage(path, image);

            AssetDatabase.Refresh();
        }

        public static void SaveImages(SDToolProfile profile, Texture2D[] images, bool[] selection)
        {
            var path = GetPath(profile);

            for (int i = 0; i < images.Length; i++)
                if (selection[i])
                    SaveImage(path, images[i]);

            AssetDatabase.Refresh();
        }

        static string GetPath(SDToolProfile profile)
        {
            var path = AssetDatabase.GetAssetPath(profile);
            return path.Substring(0, path.Length - 6);
        }

        static void SaveImage(string path, Texture2D image)
        {
            var assetPath = AssetDatabase.GenerateUniqueAssetPath($"{path} Sprite.png");
            var bytes = image.EncodeToPNG();

            File.WriteAllBytes(assetPath, bytes);
        }
    }
}