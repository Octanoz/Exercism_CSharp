namespace BottleSong;
using System.Text;


public static class GreenBottleSinger
{
    public static readonly List<string> number = ["no", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];

    public static string[] Recite(int startBottles, int takeDown)
    {
        List<string> lines = [];
        int currentBottles = startBottles;
        while (takeDown > 0)
        {
            lines.Add($"{number[currentBottles]} {(currentBottles is 1 ? "green bottle" : "green bottles")} hanging on the wall,");
            // lines.Add($"{number[currentBottles]} {(currentBottles is 1 ? "green bottle" : "green bottles")} hanging on the wall,");
            lines.Add(lines[^1]);

            lines.Add($"And if one green bottle should accidentally fall,");

            currentBottles -= 1;
            lines.Add($"There'll be {number[currentBottles].ToLower()} {(currentBottles is 1 ? "green bottle" : "green bottles")} hanging on the wall.");

            if (--takeDown > 0)
                lines.Add("");
        }

        return [.. lines];
    }
}
