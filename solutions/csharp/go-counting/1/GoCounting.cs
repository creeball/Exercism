public enum Owner
{
    None,
    Black,
    White
}

public class GoCounting(string input)
{
    private readonly char[][] _board = input.Split("\n").Select(s => s.ToCharArray()).ToArray();
    public Tuple<Owner, HashSet<(int, int)>> Territory((int x, int y) coord)
    {
        if (!Check(coord)) throw new ArgumentException();
        HashSet<(int, int)> set = [];
        Stack<(int, int)> stack = new([coord]);
        HashSet<Owner> owners = [];
        while (stack.Count > 0)
        {
            (int x, int y) pos = stack.Pop();
            if (_board[pos.y][pos.x] == 'B') owners.Add(Owner.Black);
            else if (_board[pos.y][pos.x] == 'W') owners.Add(Owner.White);
            else
            {
                if (!set.Add(pos)) continue;
                foreach (var next in Nearby(pos))
                    if (!set.Contains(next)) stack.Push(next);
            }
        }
        return new Tuple<Owner, HashSet<(int, int)>> (owners.Count != 1 || set.Count == 0 ? Owner.None : owners.First(), set);
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        Dictionary<Owner, HashSet<(int, int)>> dict = new()
        {
            [Owner.None] = [],
            [Owner.Black] = [],
            [Owner.White] = []
        };
        for (int y = 0; y < _board.Length; y++)
        {
            for (int x = 0; x < _board[0].Length; x++)
            {
                var pos = (x, y);
                if (dict.Any(p => p.Value.Contains(pos))) continue;
                var territory = Territory(pos);
                dict[territory.Item1].UnionWith(territory.Item2);
            }
        }
        return dict;
    }

    private IEnumerable<(int, int)> Nearby((int x, int y) coord)
    {
        (int, int)[] coords = 
        [
            (coord.x + 1, coord.y),
            (coord.x - 1, coord.y),
            (coord.x, coord.y + 1),
            (coord.x, coord.y - 1)
        ];
        foreach ((int x, int y) next in coords)
            if (Check(next)) yield return next;
    }
    
    private bool Check((int x, int y) coord) => 
        coord.y >= 0 && coord.y < _board.Length && coord.x >= 0 && coord.x < _board[0].Length;
}
