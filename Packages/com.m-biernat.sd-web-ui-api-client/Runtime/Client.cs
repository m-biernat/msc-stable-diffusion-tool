using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SDWebUIAPIClient
{
    public class Client
    {
        const string DefaultAddress = "http://127.0.0.1:7860";
        const double DefaultTimeout = 30;
        const string AddressKey = "SDToolServerAddress";

        static HttpClient _httpClient;

        public static HttpClient ActiveInstance
        {
            get
            {
                if (HasNoActiveInstance())
                    Init(LoadAddress());

                return _httpClient;
            }
        }

        public static bool HasNoActiveInstance() => _httpClient == null;

        public static string LoadAddress()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorPrefs.HasKey(AddressKey))
                return UnityEditor.EditorPrefs.GetString(AddressKey);
#else
            if (UnityEngine.PlayerPrefs.HasKey(AddressKey))
                return UnityEngine.PlayerPrefs.GetString(AddressKey);
#endif
            return DefaultAddress;
        }

        public static void Init(string baseAddress = DefaultAddress,
                                double timeout = DefaultTimeout)
        {
            _httpClient = new HttpClient();

            SetBaseAddress(baseAddress);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            SetTimeout(timeout);
        }

        static void SetBaseAddress(string baseAddress)
            => _httpClient.BaseAddress = new Uri(baseAddress);

        static void SetTimeout(double valueInMinutes)
            => _httpClient.Timeout = TimeSpan.FromMinutes(valueInMinutes);

        public static void ChangeAddress(string newAddress)
        {
            if (!HasNoActiveInstance())
                SetBaseAddress(newAddress);
#if UNITY_EDITOR
            UnityEditor.EditorPrefs.SetString(AddressKey, newAddress);
#else
            UnityEngine.PlayerPrefs.SetString(AddressKey, newAddress);
#endif
        }

        public static void ResetAddress()
            => ChangeAddress(DefaultAddress);
    }
}