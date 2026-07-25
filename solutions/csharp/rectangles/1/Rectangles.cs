public static class Rectangles
{
    public static int Count(string[] rows)
    {
        char[][] map = rows.Select(s => s.ToCharArray()).ToArray();
        List<(int X, int Y)> corners = new();
        
        for (int line = 0; line < map.Length; line++)
            for (int i = 0; i < map[0].Length; i++)
                if (map[line][i] == '+') corners.Add((i, line));
        
        return corners.Select((corner1, i) => corners.Where((corner2, j) => j > i && Check(corner1, corner2)).Count()).Sum();

        bool Check((int X, int Y) firstPoint, (int X, int Y) secondPoint)
        {
            if (firstPoint.Y >= secondPoint.Y || firstPoint.X >= secondPoint.X) return false;
            for (int x = firstPoint.X; x <= secondPoint.X; x++)
            {
                if (map[firstPoint.Y][x] != '-' && map[firstPoint.Y][x] != '+') return false;
                if (map[secondPoint.Y][x] != '-' && map[secondPoint.Y][x] != '+') return false;
            }

            for (int y = firstPoint.Y; y <= secondPoint.Y; y++)
            {
                if (map[y][firstPoint.X] != '|' && map[y][firstPoint.X] != '+') return false;
                if (map[y][secondPoint.X] != '|' && map[y][secondPoint.X] != '+') return false;
            }

            return true;
        }
    }
}