namespace DartMethods;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);

        return distance switch
        {
            <= 1 => 10,
            <= 5 => 5,
            <= 10 => 1,
            _ => 0
        };
    }

}