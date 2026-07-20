public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int value = Enumerable.Range(1, max).Sum();
        return value * value;
    }

    public static int CalculateSumOfSquares(int max)
    {
        return Enumerable.Range(1, max).Select(value => value * value).Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}