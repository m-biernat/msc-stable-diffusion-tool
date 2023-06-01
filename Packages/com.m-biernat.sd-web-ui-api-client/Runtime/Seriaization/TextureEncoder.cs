using System;
using UnityEngine;

namespace SDWebUIAPIClient.Serialization
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

            Texture2D texture = new Texture2D(0, 0, TextureFormat.ARGB32, false, true);
            texture.LoadImage(imageData);

            return texture;
        }
    }
}