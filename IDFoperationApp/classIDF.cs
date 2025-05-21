
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
     interface IOrganization
    {
        DateTime FormatDate { get; set; }
        string CurrentCommander { get; set; }
    }
}

public class IDF : IOrganization
{

    public DateTime FormatDate { get; set; }

    public string CurrentCommander { get; set; }





}




internal interface IStrikeOptions
{
    string AUniqueName { get; set; }

    string AmmunitionCapacity { get; set; }

    void FuelSupply();

    List<string> typeOfTartet();
}

