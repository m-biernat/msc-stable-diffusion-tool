using System;
using UnityEngine;

namespace SDTool.APIClient.Serialization
{
    public static class TextureEncoder
    {
        public static string Texture2DToBase64(Texture2D texture)
        {
            var imageData = texture.EncodeToPNG();
            return Convert.ToBase64String(imageData, Base64FormattingOptions.InsertLineBreaks);
        }

        public static Texture2D Base64ToTexture2D(string encodedData)
        {
            var imageData = Convert.FromBase64String(encodedData);

            int width, height;
            GetImageSize(imageData, out width, out height);

            Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
            texture.LoadImage(imageData);

            return texture;
        }

        static void GetImageSize(byte[] imageData, out int width, out int height)
        {
            width = ReadInt(imageData, 3 + 15);
            height = ReadInt(imageData, 3 + 15 + 2 + 2);
        }

        static int ReadInt(byte[] imageData, int offset)
            => imageData[offset] << 8 | imageData[offset + 1];
    }
}