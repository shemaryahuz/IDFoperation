using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for creating strike options using Gemini API
    internal static class StrikeFactory
    {
        // Property for Json Options
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        // This method returns a prompt for creating a Plain object
        public static string GetPlainPrompt()
        {
            return "Generate a JSON object for a Plain with a propery of 'uniqueName' (string that represent the Plain's name)";
        }
        // This method returns a prompt for creating a Drone object
        public static string GetDronePrompt()
        {
            return "Generate a JSON object for a Drone with a propery of 'uniqueName' (string that represent the Drone's name)";
        }
        // This method returns a prompt for creating an Artillery object
        public static string GetArtilleryPrompt()
        {
            return "Generate a JSON object for a Artillery with a propery of 'uniqueName' (string that represent the Artillery's name)";
        }
        // This method is converting the string json to a Plain object
        public static Plain ParsePlain(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON string must not be null or empty.", nameof(json));
            }
            try
            {
                Plain plain = JsonSerializer.Deserialize<Plain>(json, _jsonSerializerOptions);
                return plain;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse Plain: {ex.Message}");
                return null;
            }
        }
        // This method is converting the string json to a Drone object
        public static Drone ParseDrone(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON string must not be null or empty.", nameof(json));
            }
            try
            {
                Drone drone = JsonSerializer.Deserialize<Drone>(json, _jsonSerializerOptions);
                return drone;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse Drone: {ex.Message}");
                return null;
            }
        }
        // This method is converting the string json to an artillery object
        public static Artillery ParseArtillery(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON string must not be null or empty.", nameof(json));
            }
            try
            {
                Artillery artillery = JsonSerializer.Deserialize<Artillery>(json, _jsonSerializerOptions);
                return artillery;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse Artillery: {ex.Message}");
                return null;
            }
        }
        // This method is adding the created Plain to the Strike Unit
        public static void AddPlain(Plain plain)
        {
            StrikeUnit.GetInstance().StrikeOptionsData["Plains"].Add(plain);
        }
        // This method is adding the created Drone to the Strike Unit
        public static void AddDrone(Drone drone)
        {
            StrikeUnit.GetInstance().StrikeOptionsData["Drones"].Add(drone);
        }
        // This method is adding the created Artillery to the Strike Unit
        public static void AddArtillery(Artillery artillery)
        {
            StrikeUnit.GetInstance().StrikeOptionsData["Artilleries"].Add(artillery);
        }
    }
}
