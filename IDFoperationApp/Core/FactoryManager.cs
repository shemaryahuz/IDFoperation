using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for creating objects for the operation, using the factories
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
            Console.WriteLine("Creating Terrorists...");
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(TerroristFactory.GetTerroristPrompt());
                Terrorist terrorist = TerroristFactory.ParseTerrorist(jsonStr);
                TerroristFactory.AddTerrorist(terrorist);
            }
        }
        public static async Task CreatePlains()
        {
            Console.WriteLine("Creating Plains...");
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetPlainPrompt());
                Plain plain = StrikeFactory.ParsePlain(jsonStr);
                StrikeFactory.AddPlain(plain);
            }
        }
        public static async Task CreateDrones()
        {
            Console.WriteLine("Creating Drones...");
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetDronePrompt());
                Drone drone = StrikeFactory.ParseDrone(jsonStr);
                StrikeFactory.AddDrone(drone);
            }
        }
        public static async Task CreateArtilleries()
        {
            Console.WriteLine("Creating Artilleriess...");
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(StrikeFactory.GetArtilleryPrompt());
                Artillery artillery = StrikeFactory.ParseArtillery(jsonStr);
                StrikeFactory.AddArtillery(artillery);
            }
        }
        public static async Task CreateIntelMessage()
        {
            Console.WriteLine("Creating Intelligance Messages...");
            for (int i = 0; i < 3; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(IntelMessageFactory.GetMessagePrompt());
                IntelMessage intelMessage = IntelMessageFactory.ParseIntelMessage(jsonStr);
                IntelMessageFactory.AddIntelMessage(intelMessage);
            }
        }
    }
}
