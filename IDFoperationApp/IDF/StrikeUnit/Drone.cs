using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Drone: IStrikeOption
    {
        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
        [JsonPropertyName("bombsType")]
        public string[] BombsType { get; set; }
        [JsonPropertyName("typeOfTarget")]
        public string[] TypeOfTarget { get; set; }
        public Drone(string uniqueName)
        {
            this.UniqueName = uniqueName;
            this.Capacity = 3;
            this.BombsType = new string[] { "Personnel", "Armored vehicles" };
            this.TypeOfTarget = new string[] { "Buildings" , "Open area"};
        }
        public void Supply()
        {
            this.Capacity += 2;
        }
    }
}
