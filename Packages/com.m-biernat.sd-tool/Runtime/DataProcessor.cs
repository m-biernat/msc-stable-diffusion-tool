using SDWebUIAPIClient.Models;
using SDWebUIAPIClient;
using SDTool.Profile;
using System.Threading.Tasks;
using UnityEngine;

namespace SDTool
{
    public static class DataProcessor
    {
        public static async Task<Texture2D> PreprocessAsync(SDToolProfile profile)
        {
            var payload = profile.ControlNet.GetPreprocessPayload();

            var result =
                await RequestProcessor<CNetPreprocessResultT2D, CNetPreprocessT2D>
                .PostAsync(Endpoints.ControlNet.Preprocess, payload);

            return result.Images[0];
        }

        public static async Task<Texture2D[]> ProcessAsync(SDToolProfile profile)
        {
            var txt2ImgPayload = profile.Txt2Img.GetPayload();

            if (profile.UseControlNet)
            {
                var controlNetPayload = profile.ControlNet.GetPayload();
                
                txt2ImgPayload.AlwaysOnScripts = new { 
                    controlnet = new { 
                        args = new CNetUnit[] { controlNetPayload }
                    } 
                };
            }

            if (!profile.UseRemBg)
            {
                var result =
                    await RequestProcessor<Txt2ImgResultT2D, Txt2Img>
                    .PostAsync(Endpoints.Txt2Img, txt2ImgPayload);

                return result.Images;
            }

            var txt2ImgResult =
                    await RequestProcessor<Txt2ImgResult, Txt2Img>
                    .PostAsync(Endpoints.Txt2Img, txt2ImgPayload);

            var extrasPayload = new ExtraSingleImage()
            {
                RemBgModel = profile.RemBgModel
            };

            var results = new Texture2D[txt2ImgResult.Images.Length];

            for (int i = 0; i < results.Length; i++)
            {
                extrasPayload.Image = txt2ImgResult.Images[i];
                var result
                    = await RequestProcessor<ExtraSingleImageResultT2D, ExtraSingleImage>
                    .PostAsync(Endpoints.ExtraSingleImage, extrasPayload);
                results[i] = result.Image;
            }

            return results;
        }
    }
}