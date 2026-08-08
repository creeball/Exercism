public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        var dictionary = GetPds(minFactor, maxFactor);
        var max = dictionary.Keys.Max();
        return (max, dictionary[max]);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        var dictionary = GetPds(minFactor, maxFactor);
        var min = dictionary.Keys.Min();
        return (min, dictionary[min]);
    }

    private static bool IsPd(int number)
    {
        string s = number.ToString();
        return s == string.Concat(s.Reverse());
    }

    private static Dictionary<int, List<(int, int)>> GetPds(int minFactor, int maxFactor)
    {
        Dictionary<int, List<(int, int)>> dictionary = [];
        for (int num1 = minFactor; num1 <= maxFactor; num1++)
        {
            for (int num2 = num1; num2 <= maxFactor; num2++)
            {
                int result = num1 * num2;
                if (!IsPd(result)) continue;
                if (dictionary.TryGetValue(result, out var value)) value.Add((num1, num2));
                else dictionary[result] = [(num1, num2)];
            }
        }
        return dictionary.Count == 0 ? throw new ArgumentException() : dictionary;
    }
}
