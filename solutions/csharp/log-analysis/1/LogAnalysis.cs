public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string substring)
    {
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substring)) return str;
        var index = str.IndexOf(substring, StringComparison.Ordinal);
        return index == -1 ? str : str[(index + substring.Length)..];
    }

    public static string SubstringBetween(this string str, string substring1, string substring2)
    {
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substring1) || string.IsNullOrEmpty(substring2)) return str;
        var index1 = str.IndexOf(substring1, StringComparison.Ordinal);
        var index2 = str.IndexOf(substring2, StringComparison.Ordinal);
        return (index1 == -1 || index2 == -1) ? str : str[(index1 + substring1.Length)..index2];
    }

    public static string Message(this string str)
    {
        return str.SubstringAfter("]: ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}