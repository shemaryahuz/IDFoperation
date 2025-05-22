using System;

public class Hermes460Drone : StrikeOptions
{
    public Hermes460Drone()
    {
        this.BombTypes = new string[] { "personnel", "armored vehicles" };

        this.TypeOfTarget = new string[] { "people", "vehicles" };

        this.AmmunitionCapacity = 3;
    }

    public override void FuelSupply()
    {
        Console.WriteLine($"the fuel and the missels is readi to attek");
        this.AmmunitionCapacity += 3;
    }
}
