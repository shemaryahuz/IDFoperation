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
        public Dictionary<string, List<IStrikeOption>> StrikeOptionsData = new Dictionary<string, List<IStrikeOption>>();
        public StrikeUnit() 
        {
            this.StrikeOptionsData = new Dictionary<string, List<IStrikeOption>>
            {
                {"Plains", new List<IStrikeOption>() },
                {"Drones", new List<IStrikeOption>() },
                {"Artilleries", new List<IStrikeOption>() }
            };
            for (int i = 0; i < 5; i++)
            {
                this.AddPlain($"F16.{i + 1}");
                this.AddDrone($"ZIK{i + 1}");
                this.AddArtillery($"M109.{i + 1}");
            }
        }
        public void AddPlain(string plainName)
        {
            this.StrikeOptionsData["Plains"].Add(new Plain(plainName));
        }
        public void AddDrone(string droneName)
        {
            this.StrikeOptionsData["Drones"].Add(new Drone(droneName));
        }
        public void AddArtillery(string artilleryName)
        {
            this.StrikeOptionsData["Artilleries"].Add(new Artillery(artilleryName));
        }
    }
}