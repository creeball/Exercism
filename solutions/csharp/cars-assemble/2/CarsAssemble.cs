using System.Diagnostics;

static class AssemblyLine
{
    public static double SuccessRate(int speed) => speed switch
    {
        1 or 2 or 3 or 4 => 1,
        5 or 6 or 7 or 8 => 0.9,
        9 => 0.8,
        10 => 0.77,
        _ => 0
    };
    public static double ProductionRatePerHour(int speed) => 221 * speed * SuccessRate(speed);
    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / 60;
}