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
            var path = GetPath(profile);

            foreach (var image in images)
                SaveImage(path, image);

            AssetDatabase.Refresh();
        }

        public static void SaveImages(ProfileData profile, Texture2D[] images, bool[] selection)
        {
            var path = GetPath(profile);

            for (int i = 0; i < images.Length; i++)
                if (selection[i])
                    SaveImage(path, images[i]);

            AssetDatabase.Refresh();
        }

        static string GetPath(ProfileData profile)
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