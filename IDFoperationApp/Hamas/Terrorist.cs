using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class represents a terrorist in hamas
    internal class Terrorist
    {
        [JsonPropertyName("Name")]
        public string Name;
        [JsonPropertyName("Rank")]
        public int Rank;
        [JsonPropertyName("IsAlive")]
        public bool IsAlive;
        [JsonPropertyName("Weapons")]
        public List<string> Weapons = new List<string>();
        public Terrorist(string name, int rank, List<string> weapons)
        {
            this.Name = name;
            this.Rank = rank;
            this.IsAlive = true;
            this.Weapons = weapons;
        }
    }
}
