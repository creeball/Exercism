public static class Grains
{
    public static ulong Square(int n) =>
        n is >= 1 and <= 64 ? 1UL << (n - 1) : throw new ArgumentOutOfRangeException(nameof(n));

    public static ulong Total()
    {
        ulong total = 0;
        for (int i = 0; i < 64; i++) total += Square(i + 1);
        return total;
    }
}