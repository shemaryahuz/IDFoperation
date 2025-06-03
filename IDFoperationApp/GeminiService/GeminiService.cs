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
        private readonly static HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey;
        private readonly string _modelName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private static GeminiService _instance;
        private GeminiService(string apiKey, string modelName = "gemini-2.0-flash")
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("API key must not be null or empty.", nameof(apiKey));
            }
            if (string.IsNullOrEmpty(modelName))
            {
                throw new ArgumentException("Model name must not be null or empty.", nameof(modelName));
            }
            _apiKey = apiKey;
            _modelName = modelName;
            _httpClient.DefaultRequestHeaders.Accept.Clear(); 
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
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
                },
                GenerationConfig = new GenerationConfig()
            };
            return geminiRequest;
        }
        private async Task<string> SendRequestAsync(GeminiRequest geminiRequest)
        {
            string jsonPayLoad = JsonSerializer.Serialize(geminiRequest, _jsonSerializerOptions);
            StringContent httpContent = new StringContent(jsonPayLoad, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(GetApiUrl(), httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API request failed with status {response.StatusCode}: {responseContent}");
            }
            return responseContent;
        }
        private string ExtractGeneratedText(string jsonResponse)
        {
            GeminiResponse geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(jsonResponse, _jsonSerializerOptions);
            string generatedText = geminiResponse?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;
            return generatedText;
        }
        public async Task<string> GenerateJsonStringAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Prompt nust not be null or empty.", nameof(prompt));
            }
            GeminiRequest geminiRequest = BuildRequest(prompt);
            string jsonResponse = await SendRequestAsync(geminiRequest);
            string generatedText = ExtractGeneratedText(jsonResponse);
            if (string.IsNullOrWhiteSpace(generatedText))
            {
                return null;
            }
            string cleanedText = generatedText.Trim();
            if (cleanedText.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
            {
                cleanedText = cleanedText.Substring(7);
            }
            else if (cleanedText.StartsWith("```"))
            {
                cleanedText = cleanedText.Substring(3);
            }

            if (cleanedText.EndsWith("```"))
            {
                cleanedText = cleanedText.Substring(0, cleanedText.Length - 3);
            }

            return cleanedText.Trim();
        }
    }
}
