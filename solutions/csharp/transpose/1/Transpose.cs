public static class Transpose
{
    public static string String(string input) =>
        string.Join('\n',
            input
                .Split('\n')
                .SelectMany((line, row) => line.Select((ch, col) => (ch, col, row)))
                .GroupBy(x => x.col)
                .Select(g => g.ToDictionary(x => x.row, x => x.ch))
                .Select(d => string.Concat(
                    Enumerable.Range(0, d.Last().Key + 1)
                        .Select(i => d.GetValueOrDefault(i, ' ')))));
}