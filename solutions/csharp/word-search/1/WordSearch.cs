public class WordSearch(string grid)
{
    private static readonly (int row, int col)[] Directions =
        [(-1, -1), (0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0)];

    private readonly string[] _rows = grid.Split('\n');

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor) =>
        wordsToSearchFor.ToDictionary(word => word, Search);

    private ((int, int), (int, int))? Search(string word) =>
        Enumerable.Range(0, _rows.Length)
            .SelectMany(row => Enumerable.Range(0, _rows[0].Length)
                .Select(col => (row, col)))
            .SelectMany(cell=> Directions
                .Select(dir => (flag: Match(word, cell, dir), cell, dir)))
            .Where(r => r.flag)
            .Select(r => (((int, int), (int, int))?)(
                (r.cell.col + 1, r.cell.row + 1),
                (r.cell.col + 1 + r.dir.col * (word.Length - 1), r.cell.row + 1 + r.dir.row * (word.Length - 1))))
            .FirstOrDefault();

    private bool Match(string word, (int row, int col) cell, (int row, int col) dir) =>
        word.Select((ch, i) => (ch, row: cell.row + dir.row * i, col: cell.col + dir.col * i))
            .All(p => InBounds(p.row, p.col) && _rows[p.row][p.col] == p.ch);

    private bool InBounds(int row, int col) =>
        row >= 0 && row < _rows.Length && col >= 0 && col < _rows[0].Length;
}