namespace KindergartenGarden;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class Garden(string diagram)
{
    private readonly string[] rows = diagram.Split();

    public IEnumerable<Plant> Plants(string student)
    {
        int studentIndex = student[0] - 'A';
        char[] plants =
        [
            rows[0][studentIndex * 2],
            rows[0][studentIndex * 2 + 1],
            rows[1][studentIndex * 2],
            rows[1][studentIndex * 2 + 1]
        ];

        return plants.Select(DecodeChar);
    }

    static Plant DecodeChar(char c) => c switch
    {
        'G' => Plant.Grass,
        'C' => Plant.Clover,
        'R' => Plant.Radishes,
        'V' => Plant.Violets,
        _ => throw new ArgumentException($"Unknown character found: {c}")
    };
}