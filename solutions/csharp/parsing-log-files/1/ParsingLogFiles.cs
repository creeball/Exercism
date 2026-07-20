    using System.Text.RegularExpressions;

    public partial class LogParser
    {
        public bool IsValidLine(string text)
        {
            return MyRegex().IsMatch(text);
        }

        public string[] SplitLogLine(string text)
        {
            return MyRegex1().Split(text);
        }

        public int CountQuotedPasswords(string lines)
        {
            return MyRegex2().Count(lines);
        }

        public string RemoveEndOfLineText(string line)
        {
            return MyRegex3().Replace(line, string.Empty);
        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var match = MyRegex4().Match(lines[i]);
                lines[i] = match.Success ? $"{match.Value}: {lines[i]}" : $"--------: {lines[i]}";
            }
            return lines;
        }

    [GeneratedRegex(@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]")]
    private static partial Regex MyRegex();
    [GeneratedRegex(@"<[\^*=-]+>")]
    private static partial Regex MyRegex1();
    [GeneratedRegex(@""".*(?i)password.*""")]
    private static partial Regex MyRegex2();
    [GeneratedRegex(@"end-of-line\d+")]
    private static partial Regex MyRegex3();
    [GeneratedRegex(@"(?i)password\w+")]
    private static partial Regex MyRegex4();
}