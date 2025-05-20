namespace YachtGameMethods;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        Array.Sort(dice);

        return category switch
        {
            YachtCategory.Ones => dice.Where(d => d == 1).Sum(),
            YachtCategory.Twos => dice.Where(d => d == 2).Sum(),
            YachtCategory.Threes => dice.Where(d => d == 3).Sum(),
            YachtCategory.Fours => dice.Where(d => d == 4).Sum(),
            YachtCategory.Fives => dice.Where(d => d == 5).Sum(),
            YachtCategory.Sixes => dice.Where(d => d == 6).Sum(),
            YachtCategory.FullHouse when FullHousePattern(dice) => dice.Sum(),
            YachtCategory.FullHouse => 0,
            YachtCategory.FourOfAKind when FourOfAKindPattern(dice, out int fourOfAKindSum) => fourOfAKindSum,
            YachtCategory.FourOfAKind => 0,
            YachtCategory.LittleStraight when dice is [1, 2, 3, 4, 5] => 30,
            YachtCategory.LittleStraight => 0,
            YachtCategory.BigStraight when dice is [2, 3, 4, 5, 6] => 30,
            YachtCategory.BigStraight => 0,
            YachtCategory.Choice => dice.Sum(),
            YachtCategory.Yacht when dice.Distinct().Count() == 1 => 50,
            _ => 0
        };
    }

    private static bool FullHousePattern(int[] dice)
    {
        Array.Sort(dice);

        bool pattern1 = dice[0] == dice[1] && dice[1] == dice[2] && dice[2] != dice[3] && dice[3] == dice[4];
        bool pattern2 = dice[0] == dice[1] && dice[1] != dice[2] && dice[2] == dice[3] && dice[3] == dice[4];

        return pattern1 || pattern2;
    }

    private static bool FirstFourSame(int[] dice) => dice[0] == dice[1] && dice[1] == dice[2] && dice[2] == dice[3];

    private static bool LastFourSame(int[] dice) => dice[1] == dice[2] && dice[2] == dice[3] && dice[3] == dice[4];

    private static bool FourOfAKindPattern(int[] dice, out int sum)
    {
        Array.Sort(dice);
        int first = dice[0];
        int second = dice[^1];

        sum = 0;

        if (dice[3] == first)
        {
            sum = dice.Take(4).Sum();
            return true;
        }
        else if (dice[1] == second)
        {
            sum = dice.Skip(1).Sum();
            return true;
        }
        else return false;
    }
}

