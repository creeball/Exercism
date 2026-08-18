public static class Diamond
{
    public static string Make(char target)
    {
        var top = Enumerable.Range('A', target - 'A' + 1)
            .Select(i => GetLine((char)i, target)).ToList();
        return string.Join("\n", top.Concat(top.Take(top.Count - 1).Reverse()));
    }

    private static string GetLine(char letter, char target)
    {
        int dev = target - letter;
        string s = letter == 'A' ? "A" : $"{letter}{new string(' ', (letter - 'A') * 2 - 1)}{letter}";
        return $"{new string(' ', dev)}{s}{new string(' ', dev)}";
    }
}