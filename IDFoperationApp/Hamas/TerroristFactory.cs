using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class TerroristFactory
    {
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
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
    }
}
