namespace ResistorColorDuo;

public static class ResistorCalculator
{
    public static int Value(string[] colors)
    {
        int len = colors.Length;
        if (len == 0)
            return 0;

        return len < 2 ? BandColorValue(colors[0]) : BandColorValue(colors[0]) * 10 + BandColorValue(colors[1]);
    }

    private static int BandColorValue(string color)
    {
        for (int i = 0; i < 10; i++)
        {
            if (color.Equals(Enum.GetName(typeof(BandColor), i), StringComparison.OrdinalIgnoreCase))
                return i;
        }

        throw new InvalidDataException($"Unknown band color found in input");
    }
}
