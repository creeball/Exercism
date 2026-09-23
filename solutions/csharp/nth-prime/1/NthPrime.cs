public static class NthPrime
{
    
    public static int Prime(int nth)
    {
        List<int> primes = [];
        for (int i = 2; primes.Count < nth; i++)
        {
            if (primes.TakeWhile(p => p * p <= i).All(p => i % p != 0))
            {
                primes.Add(i);
            }
        }
        return primes.Count == 0 ? throw new ArgumentOutOfRangeException() : primes.Last();
    }
}