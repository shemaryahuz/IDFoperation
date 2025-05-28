using IDFoperationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{

    internal class StrikeUnit
    {
        private static StrikeUnit _Instance;
        private StrikeUnit() 
        {
            StrikeOptionsData = new Dictionary<string, List<IStrikeOption>>
            {
                {"Plains", new List<IStrikeOption>() },
                {"Drones", new List<IStrikeOption>() },
                {"Artilleries", new List<IStrikeOption>() }
            };
            for (int i = 0; i < 5; i++)
            {
                AddPlain($"F16.{i + 1}");
                AddDrone($"ZIK{i + 1}");
                AddArtillery($"M109.{i + 1}");
            }
        }
        public static StrikeUnit GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new StrikeUnit();
            }
            return _Instance;
        }
        public Dictionary<string, List<IStrikeOption>> StrikeOptionsData { get; set; } = new Dictionary<string, List<IStrikeOption>>();
        public void AddPlain(string plainName)
        {
            StrikeOptionsData["Plains"].Add(new Plain(plainName));
        }
        public void AddDrone(string droneName)
        {
            StrikeOptionsData["Drones"].Add(new Drone(droneName));
        }
        public void AddArtillery(string artilleryName)
        {
            StrikeOptionsData["Artilleries"].Add(new Artillery(artilleryName));
        }
    }
}