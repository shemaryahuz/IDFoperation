using System;
public abstract class StrikeOptions
{
    protected string[] BombTypes;

    protected string uniqueName;

    public int AmmunitionCapacity;

    protected String[] TypeOfTarget;
    public virtual void FuelSupply()
    {
        Console.WriteLine($"the fuel and the missels is readi to attek");

    }

}

