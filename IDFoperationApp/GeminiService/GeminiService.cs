using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class GeminiService
    {
        private HttpClient _httpClient;
        private string _apiKey;
        private string _modelName;
        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        private static GeminiService _instance;
        private GeminiService(string apiKey, string modelName = "gemini-2.0-flash")
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("API key must not be null or empty.", nameof(apiKey));
            }
            if (string.IsNullOrEmpty(modelName))
            {
                throw new ArgumentException("Model name must not be null or empty.", nameof(modelName);
            }
            _apiKey = apiKey;
            _modelName = modelName;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static GeminiService GetInstance(string apiKey, string modelName = "gemini-2.0-flash")
        {
            if (_instance is null)
            {
                _instance = new GeminiService(apiKey, modelName);
            }
            return _instance;
        }
        private string GetApiUrl()
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new InvalidOperationException("API key is not set.");
            }
            if (string.IsNullOrEmpty(_modelName))
            {
                throw new InvalidOperationException("Model name is not set.");
            }
            return $"https://generativelanguage.googleapis.com/v1beta/models/{_modelName}:generateContent?key={_apiKey}";
        }
        private GeminiRequest BuildRequest(string prompt)
        {
            GeminiRequest geminiRequest = new GeminiRequest
            {
                Contents = new List<Content>
                {
                    new Content
                    {
                        Parts = new List<Part>
                        {
                            new Part{Text = prompt}
                        }
                    }
                }
            };
            return geminiRequest;
        }
        private async Task<string> SendRequestAsync(GeminiRequest geminiRequest)
        {
            string jsonRequest = JsonSerializer.Serialize(geminiRequest, _jsonSerializerOptions);
            StringContent httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(GetApiUrl(), httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

    }
}
