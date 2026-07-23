public static class Sieve
{
    public static int[] Primes(int limit)
    {
        bool[] isMarked = new bool[limit + 1];
        isMarked[0] = true;
        isMarked[1] = true;
        for (int i = 2; i < limit / 2; i++)
        {
            if (isMarked[i]) continue;
            for (int j = i * 2; j <= limit; j += i)
            {
                if (!isMarked[j]) isMarked[j] = true;
            }
        }
        return [.. Enumerable.Range(1, limit).Where(i => !isMarked[i])];
    }
}