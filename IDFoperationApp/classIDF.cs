
using System;
using System.Collections.Generic;

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

