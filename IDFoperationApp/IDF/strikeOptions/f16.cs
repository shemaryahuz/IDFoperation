using System;

public class F16FighterJet : StrikeOptions
{
    public F16FighterJet()
    {
        this.BombTypes = new string[] { " 0.5 ton", "1 ton" };

        this.TypeOfTarget = new string[] { "buildings" };

        this.uniqueName = "air force";

        this.AmmunitionCapacity = 8;
    }

    public override void FuelSupply()
    {
        Console.WriteLine($"the fuel and the missels is readi to attek");
        this.AmmunitionCapacity += 8;
    }
}
