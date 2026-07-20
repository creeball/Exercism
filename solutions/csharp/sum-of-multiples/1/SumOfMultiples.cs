public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(0, max).Where(i => multiples.Any(n => n != 0 && i % n == 0)).Sum();
    }
}