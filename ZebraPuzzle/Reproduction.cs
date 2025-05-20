internal static class Reproduction
{
    private const int MutationRate = 19;
    private static readonly int[] HouseIndices = [0, 1, 2, 3, 4];

    public static Population Evolve(Population pop)
    {
        Agent[] newAgents = Enumerable.Range(0, pop.Agents.Length)
            .Select(_ => Reproduce(Selection.Tournament(pop), Selection.Tournament(pop)))
            .ToArray();

        return new(newAgents, Selection.Fittest(newAgents));
    }

    static Agent Reproduce(Agent parent1, Agent parent2)
    {
        Agent child = Crossover(parent1, parent2);

        if (ShouldMutate())
            Mutate(child);

        return child;
    }

    private static Agent Crossover(Agent parent1, Agent parent2)
    {
        House[][] parentHouses = Enumerable.Range(0, 5)
            .Select(_ => Random.Shared.Next(2) == 0 ? parent1.Houses : parent2.Houses)
            .ToArray();

        House[] childHouses = Enumerable.Range(0, 5)
            .Select(i => new House(
                parentHouses[0][i].Nationality,
                parentHouses[1][i].Color,
                parentHouses[2][i].Drink,
                parentHouses[3][i].Smoke,
                parentHouses[4][i].Pet
            )).ToArray();

        return new Agent(childHouses, Selection.Fitness(childHouses));
    }

    private static bool ShouldMutate() => Random.Shared.Next(0, 100) <= MutationRate;

    private static void Mutate(Agent agent)
    {
        Random.Shared.Shuffle(HouseIndices);

        House house1 = agent.Houses[HouseIndices[0]];
        House house2 = agent.Houses[HouseIndices[1]];

        Action[] swaps =
        [
            () => (house1.Nationality, house2.Nationality) = (house2.Nationality, house1.Nationality),
            () => (house1.Color, house2.Color) = (house2.Color, house1.Color),
            () => (house1.Drink, house2.Drink) = (house2.Drink, house1.Drink),
            () => (house1.Smoke, house2.Smoke) = (house2.Smoke, house1.Smoke),
            () => (house1.Pet, house2.Pet) = (house2.Pet, house1.Pet)
        ];

        swaps[Random.Shared.Next(0, swaps.Length)]();
    }
}