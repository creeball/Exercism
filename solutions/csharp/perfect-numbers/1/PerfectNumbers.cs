public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);
        int sum = Enumerable.Range(1, number / 2).Where(i => number % i == 0).Sum();
        if (sum == number) return Classification.Perfect;
        return sum > number ? Classification.Abundant : Classification.Deficient;
    }
}