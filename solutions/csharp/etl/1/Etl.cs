public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        return old
            .SelectMany(kvp => kvp.Value
                .Select(s => new { s, kvp.Key }))
            .ToDictionary(x => x.s.ToLower(), x => x.Key);
    }
}