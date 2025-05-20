namespace Solver;

public enum Nationality { Englishman, Spaniard, Ukrainian, Japanese, Norwegian }
public enum Color { Red, Green, Ivory, Yellow, Blue }
public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }
public enum Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }
public enum Pet { Dog, Snails, Fox, Horse, Zebra }

public record struct House(Nationality Nationality, Color Color, Drink Drink, Smoke Smoke, Pet Pet);

public static class ZebraPuzzleSolver
{
    static House[] houses = new House[5];
    static bool isSolved = false;

    public static Nationality DrinksWater()
    {
        CheckSolved();
        return houses.First(h => h.Drink == Drink.Water).Nationality;
    }

    public static Nationality OwnsZebra()
    {
        CheckSolved();
        return houses.First(h => h.Pet == Pet.Zebra).Nationality;
    }

    static void CheckSolved()
    {
        if (!isSolved)
        {
            Solve();
        }
    }

    public static void Solve()
    {
        houses = new House[5];
        isSolved = Backtrack(0);
    }

    static bool Backtrack(int houseIndex)
    {
        if (houseIndex == 5)
            return Validate();

        foreach (var nationality in Enum.GetValues<Nationality>())
        {
            foreach (var color in Enum.GetValues<Color>())
            {
                foreach (var drink in Enum.GetValues<Drink>())
                {
                    foreach (var smoke in Enum.GetValues<Smoke>())
                    {
                        foreach (var pet in Enum.GetValues<Pet>())
                        {
                            if (houses.Take(houseIndex).Any(h => h.Nationality == nationality
                                                            || h.Color == color
                                                            || h.Drink == drink
                                                            || h.Smoke == smoke
                                                            || h.Pet == pet))
                            {
                                continue;
                            }

                            houses[houseIndex] = new House(nationality, color, drink, smoke, pet);

                            if (Backtrack(houseIndex + 1))
                                return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    static bool Validate()
    {
        bool Adjacent(Predicate<House> first, Predicate<House> second) =>
            Math.Abs(Array.FindIndex(houses, first) - Array.FindIndex(houses, second)) == 1;

        List<bool> checks =
        [
            houses[0].Nationality == Nationality.Norwegian,
            houses[2].Drink == Drink.Milk,
            Array.Find(houses, h => h.Nationality == Nationality.Englishman).Color == Color.Red,
            Array.Find(houses, h => h.Nationality == Nationality.Spaniard).Pet == Pet.Dog,
            Array.Find(houses, h => h.Nationality == Nationality.Ukrainian).Drink == Drink.Tea,
            Array.Find(houses, h => h.Nationality == Nationality.Japanese).Smoke == Smoke.Parliaments,
            Array.Find(houses, h => h.Smoke == Smoke.OldGold).Pet == Pet.Snails,
            Array.Find(houses, h => h.Smoke == Smoke.Kools).Color == Color.Yellow,
            Array.Find(houses, h => h.Smoke == Smoke.LuckyStrike).Drink == Drink.OrangeJuice,
            Array.Find(houses, h => h.Drink == Drink.Coffee).Color == Color.Green,
            Adjacent(first => first.Nationality == Nationality.Norwegian, second => second.Color == Color.Blue),
            Adjacent(first => first.Color == Color.Ivory, second => second.Color == Color.Green),
            Adjacent(first => first.Pet == Pet.Fox, second => second.Smoke == Smoke.Chesterfields),
            Adjacent(first => first.Smoke == Smoke.Kools, second => second.Pet == Pet.Horse)
        ];

        return checks.TrueForAll(b => b);
    }
}