using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This interface represents a strike option of the IDF's strike unit
    internal interface IStrikeOption
    {
        string UniqueName { get; set; }
        int Capacity { get; set; }
        string[] TypeOfTarget { get; set; }
        string[] BombsType { get; set; }
        void Supply();
    }
}
