using System;

public class M109Artillery : StrikeOptions
{
    public M109Artillery()
    {
        this.BombTypes = new string[] { "explosive shells" };

        this.TypeOfTarget = new String[] { "open areas" };
        this.AmmunitionCapacity = 80;///שלא יהיה יותר משתי תקיפות בו זמנית

    }
    public override void FuelSupply()
    {
        Console.WriteLine($"the fuel and the missels is readi to attek");
        this.AmmunitionCapacity += 80;
    }
}

