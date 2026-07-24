public static class FlowerField
{
    private static readonly char[] NumList = [' ', '1', '2', '3', '4', '5', '6', '7', '8'];
    public static string[] Annotate(string[] input)
    {
        var map = input.Select(s => s.ToCharArray()).ToArray();
        for (int line = 0; line < map.Length; line++)
        {
            for (int col = 0; col < map[line].Length; col++)
            {
                if (map[line][col] == '*') map.Mark((line, col));
            }
        }
        return map.Select(i => string.Concat(i)).ToArray();
    }

    public static void Mark(this char[][] input, (int y, int x) pos)
    {
        (int y, int x)[] moveList = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];
        foreach (var move in moveList)
        {
            (int y, int x) current = (pos.y + move.y, pos.x + move.x);
            if (input.IsValid(current) && input[current.y][current.x] != '*')
            {
                input[current.y][current.x] = NumList[NumList.IndexOf(input[current.y][current.x]) + 1];
            }
        }
    }

    public static bool IsValid(this char[][] input, (int y, int x) pos)
    {
        if (pos.y < 0 || pos.y >= input.Length) return false;
        if (pos.x < 0 || pos.x >= input[0].Length) return false;
        return true;
    }
}
