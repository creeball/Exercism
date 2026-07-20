public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || span > digits.Length) throw new ArgumentException();
        int result = 0;
        for (int i = 0; i + span - 1 < digits.Length; i++)
        {
            int product = 1;
            for (int j = i; j < i + span; j++) product *= char.IsDigit(digits[j]) ? digits[j] - '0' : throw new ArgumentException();
            result = Math.Max(result, product);
        }
        return result;
    }
}