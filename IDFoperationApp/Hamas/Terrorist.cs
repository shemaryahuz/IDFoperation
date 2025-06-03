using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Terrorist
    {
        [JsonPropertyName("name")]
        public string Name;
        [JsonPropertyName("rank")]
        public int Rank;
        [JsonPropertyName("isAlives")]
        public bool IsAlive;
        [JsonPropertyName("weapons")]
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
