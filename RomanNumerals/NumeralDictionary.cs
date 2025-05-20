namespace RomanNumerals;

public static class NumeralDictionary
{
    static readonly Dictionary<int, string> romanNumerals = new()
    {
        [1000] = "M",
        [900] = "CM",
        [500] = "D",
        [400] = "CD",
        [100] = "C",
        [90] = "XC",
        [50] = "L",
        [40] = "XL",
        [10] = "X",
        [9] = "IX",
        [5] = "V",
        [4] = "IV",
        [1] = "I"
    };

    public static IReadOnlyDictionary<int, string> RomanNumerals => romanNumerals;
}