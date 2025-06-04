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
    // this class is responsible for the services of Gemini, using httpClient and Gemini API KEY
    internal class GeminiService
    {
        private readonly static HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey;
        private readonly string _modelName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private static GeminiService _instance;
        // Constructor to init apiKey, modelName. adding header of json and json options
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
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }
        // This method retuerns the Gemini Service instance (using singleton pattern)
        public static GeminiService GetInstance(string apiKey, string modelName = "gemini-2.0-flash")
        {
            if (_instance is null)
            {
                _instance = new GeminiService(apiKey, modelName);
            }
            return _instance;
        }
        // This method returns the url of Gemini API with the API KEY
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
        // This method gets a prompt returns a GeminiRequest object with the prompt
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
        // This async method gets GeminiRequest send to Gemini and returns the response as json string 
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
        // This method returns the text from the json string response
        private string ExtractGeneratedText(string jsonResponse)
        {
            GeminiResponse geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(jsonResponse, _jsonSerializerOptions);
            string generatedText = geminiResponse?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;
            return generatedText;
        }
        // This method gets a prompt and returns the Gemini response as json string
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
