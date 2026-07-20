using System.Text.RegularExpressions;

static class LogLine
{
    private const string Pattern = @"^\[(.*?)\]:\s*(.*)$";
    public static string Message(string logLine)
    {
        return Regex.Match(logLine, Pattern).Groups[2].Value.Trim();
    }

    public static string LogLevel(string logLine)
    {
        return Regex.Match(logLine, Pattern).Groups[1].Value.ToLower();
    }

    public static string Reformat(string logLine)
    {
        var match = Regex.Match(logLine, Pattern);
        return $"{match.Groups[2].Value.Trim()} ({match.Groups[1].Value.ToLower()})";
    }
}