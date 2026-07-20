public static class Darts
{
    public static int Score(double x, double y)
    {
        return (x * x + y * y) switch
        {
            <= 1 => 10,
            <= 25 => 5,
            <= 100 => 1,
            _ => 0
        };
    }
}