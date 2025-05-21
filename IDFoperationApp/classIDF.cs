
using System;
using System.Collections.Generic;

public class IDF :IOrganizsion
{







}




internal interface IStrikeOptions
{
    string AUniqueName { get; set; }

    string AmmunitionCapacity { get; set; }

    void FuelSupply();

    List<string> typeOfTartet();
}

