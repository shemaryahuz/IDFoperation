using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DotNetEnv;

namespace IDFoperationApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //OperationManager.Start();
            Env.Load(@"..\..\.env");
            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            GeminiService geminiService = GeminiService.GetInstance(apiKey);
            string prompt = "Hello gemini";
            await geminiService.GenerateTextAsync(prompt);
        }
    }
}
