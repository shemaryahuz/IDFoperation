using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class represents the Hamas organization which stores a list of terrorists
    internal class Hamas: Organization
    {
        private static Hamas _Instance;
        // Constructor to init establishment date and commander name
        private Hamas()
        {
            EstablishDate = new DateTime(1987, 12, 10).Date;
            CurrentCommander = "Mohammed Sinwar";
        }
        // This method return the instance of hamas (using singleton pattern)
        public static Hamas GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new Hamas();
            }
            return _Instance;
        }
        public List<Terrorist> Terrorists { get; set; } = new List<Terrorist>();
    }
}
