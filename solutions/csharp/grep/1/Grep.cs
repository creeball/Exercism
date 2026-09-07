public static class Grep
{
    [Flags]
    private enum Flag
    {
        None                = 0,
        PrintLineNumbers    = 1 << 0,
        PrintFileNames      = 1 << 1,
        CaseInsensitive     = 1 << 2,
        Invert              = 1 << 3,
        MatchEntireLines    = 1 << 4
    }
    
    public static string Match(string pattern, string flags, string[] files)
    {
        Flag flag = flags.Split(' ').Aggregate(Flag.None, (flag, str) => flag | Parse(str));
        List<string> output = [];
        foreach (var file in files)
        {
            string[] lines = File.ReadAllLines(file);
            var match = lines
                .Select((line, index) => (Content: line, LineNumber: (index + 1)))
                .Where(line => LineMatch(line.Content, pattern, flag));
            if (flag.HasFlag(Flag.PrintFileNames))
            {
                if (match.Any()) output.Add(file);
            }
            else output.AddRange(match.Select(line =>
                ((files.Length == 1), (flag.HasFlag(Flag.PrintLineNumbers))) switch 
                {
                    (false, false) => $"{file}:{line.Content}",
                    (true, false) => $"{line.Content}",
                    (false, true) => $"{file}:{line.LineNumber}:{line.Content}",
                    (true, true) => $"{line.LineNumber}:{line.Content}"
                }));
        }
        return string.Join("\n", output);
    }
    
    private static bool LineMatch(string line, string pattern, Flag flag)
    {
        if (flag.HasFlag(Flag.CaseInsensitive)) (line, pattern) = (line.ToLower(), pattern.ToLower());
        var match = flag.HasFlag(Flag.MatchEntireLines) ? line == pattern : line.Contains(pattern);
        return flag.HasFlag(Flag.Invert) ? !match : match;
    }

    private static Flag Parse(string flag) =>
        flag switch
        {
            "-n" => Flag.PrintLineNumbers,
            "-l" => Flag.PrintFileNames,
            "-i" => Flag.CaseInsensitive,
            "-v" => Flag.Invert,
            "-x" => Flag.MatchEntireLines,
            _ => Flag.None
        };
}