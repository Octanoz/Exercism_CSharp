using System.Text;
using RomanNumerals;

int[] arabicNumbers = [1994, 2005, 1981, 1488];
string[] expectedResults = ["MCMXCIV", "MMV", "MCMLXXXI", "MCDLXXXVIII"];

List<(int, string[])> rN =
[
    (1000, ["", "M", "MM", "MMM",]),
    (100, ["", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"]),
    (10, ["", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"]),
    (1, ["", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"]),
];

for (int i = 0; i < arabicNumbers.Length; i++)
{
    Console.WriteLine($"\n{arabicNumbers[i]} written in Roman Numerals is: {expectedResults[i]}");
    Console.WriteLine($"My List result: {ConvertToRoman(arabicNumbers[i])}");
    Console.WriteLine($"My Dictionary result: {RomanNumeralExtension.ConvertToRoman(arabicNumbers[i])}");
    Console.WriteLine("------------------");
}

string ConvertToRoman(int arabicNumber)
{
    StringBuilder sb = new();
    foreach (var (number, romanNumeral) in rN)
    {
        sb.Append(romanNumeral[arabicNumber % (number * 10) / number]);
    }

    return sb.ToString();
}
