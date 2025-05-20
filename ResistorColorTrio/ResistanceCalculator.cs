namespace ResistorColorTrio;

class ResistanceCalculator
{
    static readonly List<string> validColors =
    [
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    ];

    public static string LabelList(string[] colors)
    {
        int resistance = (validColors.IndexOf(colors[0].ToLower())
                                    * 10
                                    + validColors.IndexOf(colors[1].ToLower()))
                                    * (int)Math.Pow(10, validColors.IndexOf(colors[2].ToLower()));

        return resistance >= 1000 ? $"{resistance / 1000} kiloohms" : $"{resistance} ohms";
    }

    public static string Label(string[] colors)
    {
        int colorValues = BandValue(colors);
        int exponent = colorValues % 10;
        int resistance = colorValues / 10 * (int)Math.Pow(10, exponent);

        return exponent > 1 ? $"{resistance / 1000} kiloohms" : $"{resistance} ohms";
    }

    static int BandValue(string[] colors)
    {
        int result = 0;
        foreach (var color in colors)
        {
            result *= 10;
            result += (int)Enum.Parse(typeof(BandColor), color, true);
        }

        return result;
    }

}