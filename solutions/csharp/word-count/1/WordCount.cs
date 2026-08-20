using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        Dictionary<string, int> wordCounts = [];
        var matches = Regex.Matches(phrase, @"\w+(?:'\w+)*");
        foreach (var value in matches.Select(m => m.Value.ToLower()))
        {
            if (!wordCounts.TryAdd(value, 1))
            {
                wordCounts[value]++;
            }
        }
        return wordCounts;
    }
}