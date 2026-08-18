public static class Diamond
{
    public static string Make(char target)
    {
        List<string> lines = [];
        for (char i = 'A'; i < target; i++)
        {
            lines.Add(GetLine(i, target));
        }
        for (char i = target; i >= 'A'; i--)
        {
            lines.Add(GetLine(i, target));
        }
        return string.Join("\n", lines);
    }

    private static string GetLine(char letter, char target)
    {
        int dev = target - letter;
        string s = letter == 'A' ? "A" : $"{letter}{new string(' ', (letter - 'A') * 2 - 1)}{letter}";
        return $"{new string(' ', dev)}{s}{new string(' ', dev)}";
    }
}