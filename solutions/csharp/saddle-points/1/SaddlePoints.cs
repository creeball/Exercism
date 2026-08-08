public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int row, int col)> list1 = [];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var list = Enumerable.Range(0, matrix.GetLength(1)).Select(col => matrix[row, col]).ToList();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == list.Max()) list1.Add((row + 1, col + 1));
            }
        }
        List<(int row, int col)> list2 = [];
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            var list = Enumerable.Range(0, matrix.GetLength(0)).Select(row => matrix[row, col]).ToList();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == list.Min()) list2.Add((row + 1, col + 1));
            }
        }
        return list1.Intersect(list2);
    }
}