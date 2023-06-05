using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor
{
    public static class SDToolManager
    {
        public static T CreateAsset<T>(string name) where T : SDToolAsset
        {
            var assetPath = AssetDatabase.GenerateUniqueAssetPath(
                $"Assets/New SDTool {name}.asset");

            var instance = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(instance, assetPath);

            return AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }

        public static T CloneAsset<T>(T asset) where T : SDToolAsset
        {
            if (!asset) return null;

            var assetPath = AssetDatabase.GetAssetPath(asset);
            var clonePath = AssetDatabase.GenerateUniqueAssetPath(assetPath);

            if (!AssetDatabase.CopyAsset(assetPath, clonePath))
            {
                Debug.LogWarning($"Failed to copy {asset.name}");
                return asset;
            }

            return AssetDatabase.LoadAssetAtPath<T>(clonePath);
        }

        public static async void Interrupt() => await DataProcessor.Interrupt();

        public static async void Preprocess(ProfileData profile,
                                            Action<ProfileData, Texture2D> callback)
        {
            var result = await DataProcessor.PreprocessAsync(profile);

            callback.Invoke(profile, result);
        }

        public static async void Process(ProfileData profile, 
                                         Action<ProfileData, Texture2D[]> callback)
        {
            var result = await DataProcessor.ProcessAsync(profile);

            if (profile.AutoSaveImages)
                SaveImages(profile, result);
            else
                callback.Invoke(profile, result);
        }

        public static async void Process(BatchData batch)
        {
            var profiles = batch.PrepareProfiles();

            foreach (var profile in profiles)
            {
                var result = await DataProcessor.ProcessAsync(profile);
                SaveImages(profile, result);
            }
        }

        public static void SaveImages(ProfileData profile, Texture2D[] images)
        {
            var path = GetFilePath(profile);

            foreach (var image in images)
                SaveImage(path, image);

            AssetDatabase.Refresh();
        }

        public static void SaveImages(ProfileData profile, Texture2D[] images, bool[] selection)
        {
            var path = GetFilePath(profile);

            for (int i = 0; i < images.Length; i++)
                if (selection[i])
                    SaveImage(path, images[i]);

            AssetDatabase.Refresh();
        }

        static string GetFilePath(ProfileData profile)
        {
            var assetPath = AssetDatabase.GetAssetPath(profile.Original);
            var path = assetPath.Substring(0, assetPath.Length - 6);

            var style = profile.Txt2Img.Style;

            if (style)
                path = $"{path} {style.name}";

            return $"{path} 0.png";
        }

        static void SaveImage(string path, Texture2D image)
        {
            var assetPath = AssetDatabase.GenerateUniqueAssetPath(path);
            var bytes = image.EncodeToPNG();

            File.WriteAllBytes(assetPath, bytes);
        }
    }
}