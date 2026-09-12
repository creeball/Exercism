public static class Luhn
{
    public static bool IsValid(string number)
    {
        List<int> nums = [];
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(number[i])) continue;
            if (char.IsDigit(number[i])) nums.Add(number[i] - '0');
            else return false;
        }
        if (nums.Count <= 1) return false;
        return nums
            .Select((n, i) => i % 2 == 0 ? n : ((n *= 2) > 9 ? n - 9 : n))
            .Sum() % 10 == 0;
    }
}