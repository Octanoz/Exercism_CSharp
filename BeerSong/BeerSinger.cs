using System.Text;

namespace BeerSong;

public static class BeerSinger
{
    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder sb = new();
        while (takeDown is not 0)
        {
            sb.AppendLine($"{BeerCounter(startBottles)} on the wall, {BeerCounter(startBottles, true)}.");
            sb.Append(BeerAction(startBottles));
            sb.Append($"{BeerCounter(--startBottles, true)} on the wall.");

            if (--takeDown is not 0)
                sb.AppendLine("\n");
        }

        return sb.ToString();
    }


    static string BeerCounter(int number, bool lower = false)
    {
        return number switch
        {
            < 0 => $"{100 + number} bottles of beer",
            0 when lower => "no more bottles of beer",
            0 => "No more bottles of beer",
            1 => "1 bottle of beer",
            _ => $"{number} bottles of beer"
        };
    }

    static string BeerAction(int startBottles)
    {
        return startBottles switch
        {
            0 => "Go to the store and buy some more, ",
            1 => "Take it down and pass it around, ",
            _ => "Take one down and pass it around, "
        };
    }
}