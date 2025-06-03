using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class FactoryManager
    {
        private static GeminiService gemini = GeminiService.GetInstance(GetApiKey());
        private static string GetApiKey()
        {
            Env.Load(@"..\..\.env");
            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            return apiKey;
        }
        public static async Task CreateTerrorists()
        {
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(TerroristFactory.GetTerroristPrompt());
                Terrorist terrorist = TerroristFactory.ParseTerrorist(jsonStr);
                TerroristFactory.AddTerrorist(terrorist);
            }
        }
        public static async Task CreatePlains()
        {
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetPlainPrompt());
                Plain plain = StrikeFactory.ParsePlain(jsonStr);
                StrikeFactory.AddPlain(plain);
            }
        }
        public static async Task CreateDrones()
        {
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetDronePrompt());
                Drone drone = StrikeFactory.ParseDrone(jsonStr);
                StrikeFactory.AddDrone(drone);
            }
        }
        public static async Task CreateArtilleries()
        {
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetArtilleryPrompt());
                Artillery artillery = StrikeFactory.ParseArtillery(jsonStr);
                StrikeFactory.AddArtillery(artillery);
            }
        }
    }
}
