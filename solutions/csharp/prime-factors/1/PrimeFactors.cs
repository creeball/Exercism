public static class PrimeFactors
{
    public static long[] Factors(long number)
    { 
        List<long> factors = new();
        for (long i = 2; i * i <= number; i++)
        {
            while (number % i == 0)
            {
                number /= i;
                factors.Add(i);
            }
        }
        if (number > 1) factors.Add(number);
        return factors.ToArray();
    }
}