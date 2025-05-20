using ZebraPuzzler;

public record struct House(Nationality Nationality, Color Color, Drink Drink, Smoke Smoke, Pet Pet);
public record struct Agent(House[] Houses, double Fitness);
public record struct Population(Agent[] Agents, Agent Fittest);

internal static class Simulation
{
    private const int PopulationSize = 100_000;
    private const int MaxNumberOfGenerations = 1_000;

    public static Agent Run()
    {
        Population population = Initialization.RandomPopulation(PopulationSize);

        for (int i = 0; i < MaxNumberOfGenerations; i++)
        {
            if (population.Fittest.Fitness >= 1.0)
                return population.Fittest;

            population = Reproduction.Evolve(population);
        }

        throw new InvalidOperationException("Could not find solution...");
    }

}