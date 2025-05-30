using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class GeminiService
    {
        private static GeminiService _instance;
        public static GeminiService GetGemini(string apiKey, string modelName = "gemini-2.0-flash")
        {
            if (_instance is null)
            {
                _instance = new GeminiService(apiKey, modelName);
            }
            return _instance;
        }
        private GeminiService(string apiKey, string modelName = "gemini-2.0-flash")
        {

        }
        private HttpClient httpClient;
        private string _apiKey;
        private string _modelName;
        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }
}
