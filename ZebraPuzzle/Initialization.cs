using ZebraPuzzler;

internal static class Initialization
{
    static readonly Nationality[] Nationalities = Enum.GetValues<Nationality>();
    static readonly Color[] Colors = Enum.GetValues<Color>();
    static readonly Drink[] Drinks = Enum.GetValues<Drink>();
    static readonly Smoke[] Smokes = Enum.GetValues<Smoke>();
    static readonly Pet[] Pets = Enum.GetValues<Pet>();

    public static Population RandomPopulation(int size)
    {
        Agent[] agents = Enumerable.Range(0, size).Select(_ => RandomAgent()).ToArray();

        return new(agents, Selection.Fittest(agents));
    }

    static Agent RandomAgent()
    {
        Random.Shared.Shuffle(Nationalities);
        Random.Shared.Shuffle(Colors);
        Random.Shared.Shuffle(Drinks);
        Random.Shared.Shuffle(Smokes);
        Random.Shared.Shuffle(Pets);

        House[] houses = Enumerable.Range(0, 5).Select(RandomHouse).ToArray();

        return new Agent(houses, Selection.Fitness(houses));
    }

    static House RandomHouse(int i) => new(Nationalities[i], Colors[i], Drinks[i], Smokes[i], Pets[i]);
}