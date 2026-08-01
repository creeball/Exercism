public enum ConnectWinner
{
    White,
    Black,
    None
}

public class Connect
{
    private static readonly (int row, int col)[] Vectors = [(0, 1), (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1)];
    private readonly char[][] _map;
    private readonly HashSet<(int row, int col)> _connectedWhite = [];
    private readonly HashSet<(int row, int col)> _connectedBlack = [];
    public Connect(string[] input) => _map = input.Select(line => line.Where(c => c is '.' or 'O' or 'X').ToArray()).ToArray();

    public ConnectWinner Result()
    {
        for(int i = 0; i < _map[0].Length; i++)
        {
            if (WhiteCheck(0, i)) return ConnectWinner.White;
        }
        for (int i = 0; i < _map.Length; i++)
        {
            if (BlackCheck(i, 0)) return ConnectWinner.Black;
        }
        return ConnectWinner.None;
    }

    private bool WhiteCheck(int row, int col)
    {
        if (_map[row][col] != 'O') return false;
        if (row == _map.Length - 1) return true;
        foreach (var vector in Vectors)
        {
            (int row, int col) pos = (row + vector.row, col + vector.col);
            if (!IsAvailable(pos.row, pos.col)) continue;
            if (!_connectedWhite.Add((pos.row, pos.col))) continue;
            if (WhiteCheck(pos.row, pos.col)) return true;
        }
        return false;
    }
    
    private bool BlackCheck(int row, int col)
    {
        if (_map[row][col] != 'X') return false;
        if (col == _map[0].Length - 1) return true;
        foreach (var vector in Vectors)
        {
            (int row, int col) pos = (row + vector.row, col + vector.col);
            if (!IsAvailable(pos.row, pos.col)) continue;
            if (!_connectedBlack.Add((pos.row, pos.col))) continue;
            if (BlackCheck(pos.row, pos.col)) return true;
        }
        return false;
    }

    private bool IsAvailable(int row, int col) => row >= 0 && row < _map.Length && col >= 0 && col < _map[0].Length;
}