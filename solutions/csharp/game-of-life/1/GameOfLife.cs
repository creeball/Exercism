public static class GameOfLife
{
    private static readonly (int row, int col)[] Round =
    [
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1)
    ];

    private static IEnumerable<(int row, int col)> CellsAround(this int[,] matrix, (int row, int col) cell)
    {
        var size = (matrix.GetLength(0), matrix.GetLength(1));
        return Round.Select(p => (cell.row + p.row, cell.col + p.col)).Where(p => IsValid(size, p));
    }

    private static bool IsValid((int row, int col) size, (int row, int col) pos) =>
        pos.row >= 0 && pos.row < size.row && pos.col >= 0 && pos.col < size.col;

    private static int Update(this int[,] matrix, (int row, int col) cell)
    {
        var value = matrix[cell.row, cell.col];
        var count = matrix.CellsAround(cell).Count(c => matrix[c.row, c.col] == 1);
        return (value, count) switch
        {
            (1, 2) or (1, 3) or (0, 3) => 1,
            _ => 0
        };
    }

    public static int[,] Tick(int[,] matrix)
    {
        var (rows, cols) = (matrix.GetLength(0), matrix.GetLength(1));
        var next = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                next[row, col] = matrix.Update((row, col));
            }
        }
        return next;
    }
}
