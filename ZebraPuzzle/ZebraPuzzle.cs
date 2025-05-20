namespace ZebraPuzzler;

public enum Color { Red, Green, Ivory, Yellow, Blue }
public enum Nationality { Englishman, Spaniard, Ukranian, Japanese, Norwegian }
public enum Pet { Dog, Snails, Fox, Horse, Zebra }
public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }
public enum Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }

public static class ZebraPuzzle
{
    public static Nationality DrinksWater() => Solver.Value.Houses.First(house => house.Drink == Drink.Water).Nationality;

    public static Nationality OwnsZebra() => Solver.Value.Houses.First(house => house.Pet == Pet.Zebra).Nationality;

    private static readonly Lazy<Agent> Solver = new(Simulation.Run);
}

