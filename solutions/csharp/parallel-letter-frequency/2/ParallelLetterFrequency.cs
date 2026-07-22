public static class ParallelLetterFrequency
{
    public static Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts)
    {
        return Task.Run(() =>
        {
            Dictionary<char, int> dictionary = new();
            object sync = new();
            Parallel.ForEach(texts, () => new Dictionary<char, int>(),
                (s, _, local) =>
                {
                    foreach (var c in s)
                    {
                        if (!char.IsLetter(c)) continue;
                        char letter = char.ToLower(c);
                        if (!local.TryAdd(letter, 1)) local[letter]++;
                    }
                    return local;
                },
                local =>
                {
                    lock (sync)
                        foreach (var kvp in local)
                            if (!dictionary.TryAdd(kvp.Key, kvp.Value))
                                dictionary[kvp.Key] += kvp.Value;
                });
            return dictionary;
        });
    }
}