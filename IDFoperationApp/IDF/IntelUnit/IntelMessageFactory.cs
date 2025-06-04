using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for creating intel messages using Gemini API
    internal static class IntelMessageFactory
    {
        // Property for Json Options
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        // This method returns a prompt for creating intel message object
        public static string GetMessagePrompt()
        {
            return "Generate a JSON object for a IntelMessage with the following properties: terroristName (string)";
        }
        // This method is converting the string json to an intel message object
        public static IntelMessage ParseIntelMessage(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON string must not be null or empty.", nameof(json));
            }
            try
            {
                IntelMessage intelMessage = JsonSerializer.Deserialize<IntelMessage>(json, _jsonSerializerOptions);
                return intelMessage;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse IntelMessage: {ex.Message}");
                return null;
            }
        }
        // This method is adding the created message to the intelUnit and adding the terrorist to the intelUnit's terrorists-data if it's not exists
        public static void AddIntelMessage(IntelMessage message)
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            intelUnit.IntelMessages.Add(message);
            if (intelUnit.IntelTerrorists.ContainsKey(message.TerroristName))
            {
                intelUnit.IntelTerrorists[message.TerroristName].Reports++;
            }
            else
            {
                intelUnit.AddIntelTerrorist(message.TerroristName);
            }
        }
    }
}
