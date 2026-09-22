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
    private static decimal Solve(Dictionary<string, decimal> dictionary, int[] counts)
    {
        var key = string.Join(' ', counts);
        if (!dictionary.TryGetValue(key, out var value))
        {
            value = Enumerable.Range(0, counts.TakeWhile(c => c != 0).Count())
                .Select(i => Solve(dictionary,
                    counts
                        .Select((c, j) => j <= i ? c - 1 : c)
                        .OrderDescending()
                        .ToArray()) + 8 * (1 - Discounts[i]) * (i + 1))
                .DefaultIfEmpty(0)
                .Min();
            dictionary.Add(key, value);
        }
        return value;
    }
}