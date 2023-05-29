using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDTool.APIClient
{
    public static class RequestProcessor<TResult> 
        where TResult : class
    {
        public static async Task<TResult> GetAsync(string endpoint)
        {
            TResult result = null;

            using (HttpResponseMessage response = await Client.ActiveInstance.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return result;
        }

        public static async Task<TResult> PostAsync(string endpoint)
        {
            TResult result = null;

            using (HttpResponseMessage response = await Client.ActiveInstance.PostAsync(endpoint, null))
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return result;
        }
    }
    
    public static class RequestProcessor<TResult, TRequest> 
        where TResult : class 
        where TRequest : class
    {
        public static async Task<TResult> PostAsync(string endpoint, TRequest payload)
        {
            TResult result = null;

            var jsonContent = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await Client.ActiveInstance.PostAsync(endpoint, httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return result;
        }
    }
}