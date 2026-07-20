public static class Pangram
{
    public static bool IsPangram(string input)
    {
        HashSet<char> set = new();
        foreach (var c in input.Where(char.IsLetter)) set.Add(char.ToLower(c));
        return set.Count == 26;
    }
}