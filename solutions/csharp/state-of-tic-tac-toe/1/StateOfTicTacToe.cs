public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe
{
    private readonly char[][] _map;
    private readonly (int row, int col)[][] _lines = 
        Enumerable.Range(0, 3)
            .Select(row => Enumerable.Range(0, 3)
                .Select(col => (row, col)).ToArray())
            .Concat(Enumerable.Range(0, 3).Select(col => Enumerable.Range(0, 3)
                .Select(row => (row, col)).ToArray()))
            .Concat([[(0, 0), (1, 1), (2, 2)],
                [(0, 2), (1, 1), (2, 0)]])
            .ToArray();
    public TicTacToe(string[] rows) => 
        _map = Enumerable.Range(0, 3)
            .Select(row => Enumerable.Range(0, 3)
                .Select(col => rows[row][col]).ToArray())
            .ToArray();

    public State State
    {
        get
        {
            int countX = 0, countO = 0;
            foreach (var row in _map)
            {
                foreach (var c in row)
                {
                    if (c == 'X') countX++;
                    else if (c == 'O') countO++;
                }
            }

            if (!(countX == countO || countX == countO + 1)) return State.Invalid;
            var lines = _lines.Select(line => string.Concat(line.Select(pos => _map[pos.row][pos.col]))).Where(line => line is "XXX" or "OOO").Distinct().ToArray();
            if (lines.Length == 0 && (countX == countO || countX == countO + 1))
            {
                return countO + countX == 9 ? State.Draw : State.Ongoing;
            }

            if (lines.Length == 1)
            {
                if (lines[0] == "XXX")
                {
                    if (countX == countO + 1) return State.Win;
                }
                else
                {
                    if (countX == countO) return State.Win;
                }
            }

            return State.Invalid;
        }
    }
}
