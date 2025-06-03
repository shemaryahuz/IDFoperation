using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class FactoryManager
    {
        private static FactoryManager _Instance;
        public static FactoryManager GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new FactoryManager();
            }
            return _Instance;
        }
        private GeminiService gemini = GeminiService.GetInstance(GetApiKey());
        private static string GetApiKey()
        {
            Env.Load(@"..\..\.env");
            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            return apiKey;
        }
        public async Task CreateTerrorists()
        {
            for (int i = 0; i < 15; i++)
            {
                string jsonStr = await gemini.GenerateJsonStringAsync(GeminiPrompts.GetTerroristPrompt());
                Terrorist terrorist = TerroristFactory.ParseTerrorist(jsonStr);
                TerroristFactory.AddTerrorist(terrorist);
            }
        }
        public void CreateStrikeOptions()
        {

        }
        public void CreateIntelMessages()
        {

        }
        public void CreateIntelTerrorists()
        {

        }
    }
}
