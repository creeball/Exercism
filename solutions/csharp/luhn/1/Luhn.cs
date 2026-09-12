public static class Luhn
{
    public static bool IsValid(string number)
    {
        List<int> nums = [];
        foreach (var n in number)
        {
            if (char.IsWhiteSpace(n)) continue;
            if (char.IsDigit(n)) nums.Add(n - '0');
            else return false;
        }
        if (nums.Count <= 1) return false;
        nums.Reverse();
        return nums
            .Select((n, i) => i % 2 == 0 ? n : ((n *= 2) > 9 ? n - 9 : n))
            .Sum() % 10 == 0;
    }
}