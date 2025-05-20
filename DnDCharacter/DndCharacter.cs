namespace DnD;

public class DndCharacter
{
    private static readonly Random RNG = new();
    private const int AbilityRolls = 4;
    private const int SixSidedDie = 7;

    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }
    public int Hitpoints { get; init; }

    private static int Modifier(int score) => (int)Math.Floor((score - 10.0) / 2);

    private static int Ability()
    {
        int[] rolls = new int[AbilityRolls];
        for (int i = 0; i < AbilityRolls; i++)
        {
            rolls[i] = RNG.Next(1, SixSidedDie);
        }

        // return rolls.Sum() - rolls.Min();
        return rolls.OrderDescending().Take(3).Sum();
    }

    private static int Ability(out int result)
    {
        int[] rolls = new int[AbilityRolls];
        for (int i = 0; i < AbilityRolls; i++)
        {
            rolls[i] = RNG.Next(1, SixSidedDie);
        }

        result = rolls.OrderDescending().Take(3).Sum();
        return result;
    }

    public static DndCharacter Generate() => new()
    {
        Strength = Ability(),
        Dexterity = Ability(),
        Constitution = Ability(out int constitution),
        Intelligence = Ability(),
        Wisdom = Ability(),
        Charisma = Ability(),
        Hitpoints = 10 + Modifier(constitution)
    };
}