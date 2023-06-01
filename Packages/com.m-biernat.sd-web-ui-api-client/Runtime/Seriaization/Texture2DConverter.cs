using Newtonsoft.Json;
using System;
using UnityEngine;

namespace SDWebUIAPIClient.Serialization
{
    public class Texture2DConverter : JsonConverter<Texture2D>
    {
        public override Texture2D ReadJson(JsonReader reader, Type objectType, Texture2D existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return TextureEncoder.Base64ToTexture2D((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, Texture2D value, JsonSerializer serializer)
        {
            if (value)
                writer.WriteValue(TextureEncoder.Texture2DToBase64(value));
            else
                writer.WriteValue((string)null);
        }
    }
}
