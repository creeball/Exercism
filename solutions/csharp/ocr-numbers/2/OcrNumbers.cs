public static class OcrNumbers
{
    private static readonly Dictionary<string, char> Numbers = new() 
    {
        [
            " _ " +
            "| |" +
            "|_|" +
            "   "
        ] = '0',
        [
            "   " +
            "  |" +
            "  |" +
            "   "
        ] = '1',
        [
            " _ " +
            " _|" +
            "|_ " +
            "   "
        ] = '2',
        [
            " _ " +
            " _|" +
            " _|" +
            "   "
        ] = '3',
        [
            "   " +
            "|_|" +
            "  |" +
            "   "
        ] = '4',
        [
            " _ " +
            "|_ " +
            " _|" +
            "   "
        ] = '5',
        [
            " _ " +
            "|_ " +
            "|_|" +
            "   "
        ] = '6',
        [
            " _ " +
            "  |" +
            "  |" +
            "   "
        ] = '7',
        [
            " _ " +
            "|_|" +
            "|_|" +
            "   "
        ] = '8',
        [
            " _ " +
            "|_|" +
            " _|" +
            "   "
        ] = '9'
    };
    public static string Convert(string input)
    {
        var split = input.Split('\n');
        var transposed = split.Length % 4 != 0 ? throw new ArgumentException() : split
            .Chunk(4)
            .Select(strs => strs
                .Select(s => s.Length % 3 != 0 ? throw new ArgumentException() : s
                    .Chunk(3)
                    .Select(ch => string.Concat(ch))
                    .ToArray())
                .ToArray());
        return string.Join(",", transposed
            .Select(a => string.Concat(a[0]
                .Select((_, i) => string.Concat(a
                    .Select(row => row[i])))
                .Select(s => Numbers.GetValueOrDefault(s, '?')))));
    }
}