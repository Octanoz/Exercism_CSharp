using ZebraPuzzler;

internal static class Selection
{
    private const int MaxScore = 14;
    private const int TournamentSize = 5;

    public static Agent Fittest(Agent[] agents) => agents.MaxBy(a => a.Fitness);

    public static Agent Tournament(Population pop) =>
        Random.Shared.GetItems(pop.Agents, TournamentSize).MaxBy(a => a.Fitness);

    public static double Fitness(House[] houses)
    {
        bool Adjacent(Predicate<House> first, Predicate<House> second) =>
            Math.Abs(Array.FindIndex(houses, first) - Array.FindIndex(houses, second)) == 1;

        List<bool> checks =
        [
            houses[0].Nationality == Nationality.Norwegian,
            houses[2].Drink == Drink.Milk,
            Array.Find(houses, h => h.Nationality == Nationality.Englishman).Color == Color.Red,
            Array.Find(houses, h => h.Nationality == Nationality.Spaniard).Pet == Pet.Dog,
            Array.Find(houses, h => h.Nationality == Nationality.Ukranian).Drink == Drink.Tea,
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

        return (double)checks.Count(b => b) / MaxScore;
    }
}