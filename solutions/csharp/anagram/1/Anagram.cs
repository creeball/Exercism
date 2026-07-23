public class Anagram(string baseWord)
{
    private string BaseWord { get; set; } = baseWord;
    private char[] Transform(string word) => word.ToLower().Order().ToArray();
    public string[] FindAnagrams(string[] potentialMatches) =>
        potentialMatches
            .Where(s => Transform(s).SequenceEqual(Transform(BaseWord)) && s.ToLower() != BaseWord.ToLower())
            .ToArray();
}