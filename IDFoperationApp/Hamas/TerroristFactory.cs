using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for creating terrorists using Gemini API
    internal static class TerroristFactory
    {
        // Property for Json Options
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        // This method returns a prompt for creating terrorist object
        public static string GetTerroristPrompt()
        {
            return "Generate a JSON object for a Terrorist with the following properties: Name (string that represent the name) , Rank (int that represent the rank from 1 to 5), Weapons (list of string (each string can be 'Rifle' or 'Gun' or 'Knife'))";
        }
        // This method is converting the string json to a terrorist object
        public static Terrorist ParseTerrorist(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON string must not be null or empty.", nameof(json));
            }
            try
            {
                Terrorist terrorist = JsonSerializer.Deserialize<Terrorist>(json, _jsonSerializerOptions);
                return terrorist;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse Terrorist: {ex.Message}");
                return null;
            }
        }
        // This method is adding the created terrorist to hamas
        public static void AddTerrorist(Terrorist terrorist)
        {
            Hamas.GetInstance().Terrorists.Add(terrorist);
        }
    }
}
