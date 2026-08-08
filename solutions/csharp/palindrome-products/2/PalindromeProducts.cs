public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        int max = 0;
        List<(int,int)> factors = [];
        for (int num1 = minFactor; num1 <= maxFactor; num1++)
        {
            for (int num2 = num1; num2 <= maxFactor; num2++)
            {
                int product = num1 * num2;
                if (product < max || !IsPd(product)) continue;
                if (product > max)
                {
                    max = product;
                    factors.Clear();
                }
                factors.Add((num1, num2));
            }
        }

        return factors.Count == 0 ? throw new ArgumentException() : (max, factors);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        int min = int.MaxValue;
        List<(int,int)> factors = [];
        for (int num1 = minFactor; num1 <= maxFactor; num1++)
        {
            for (int num2 = num1; num2 <= maxFactor; num2++)
            {
                int product = num1 * num2;
                if (product > min || !IsPd(product)) continue;
                if (product < min)
                {
                    min = product;
                    factors.Clear();
                }
                factors.Add((num1, num2));
            }
        }
        return factors.Count == 0 ? throw new ArgumentException() : (min, factors);
    }

    private static bool IsPd(int number)
    {
        int original = number;
        int reversed = 0;
        while (number > 0)
        {
            reversed = reversed * 10 + number % 10;
            number /= 10;
        }
        return original == reversed;
    }
}