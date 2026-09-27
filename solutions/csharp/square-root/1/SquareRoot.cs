public static class SquareRoot
{
    public static int Root(int number)
    {
        int res = 0;
        int bits = 0;
        for (var t = number; t != 0; t >>= 1) bits++;
        int bit = 1 << (bits & ~1);

        while (bit != 0)
        {
            if (number >= res + bit)
            {
                number -= res + bit;
                res = (res >> 1) + bit;
            }
            else
            {
                res >>= 1;
            }
            bit >>= 2;
        }
        return res;
    }
}
