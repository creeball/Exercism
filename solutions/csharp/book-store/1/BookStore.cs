public static class BookStore
{
    private static readonly decimal[] Discounts = [0.00m, 0.05m, 0.10m, 0.20m, 0.25m];
    public static decimal Total(IEnumerable<int> books) =>
        Solve([], 
            books
                .GroupBy(b => b)
                .Select(g => g.Count())
                .OrderDescending()
                .ToArray());

    private static decimal Solve(Dictionary<(int, string), decimal> dictionary, int[] counts) =>
        Enumerable.Range(0, counts.TakeWhile(c => c != 0).Count())
            .Select(i => GetValue(dictionary, counts, i))
            .DefaultIfEmpty(0)
            .Min();

    private static decimal GetValue(Dictionary<(int, string), decimal> dictionary, int[] counts, int i)
    {
        var key = (i, string.Join(' ', counts));
        if (!dictionary.TryGetValue(key, out var value))
        {
            value = Solve(dictionary,
                counts
                    .Select((c, j) => j <= i ? c - 1 : c)
                    .OrderDescending()
                    .ToArray()) + 8 * (1 - Discounts[i]) * (i + 1);
            dictionary.Add(key, value);
        }
        return value;
    }
}