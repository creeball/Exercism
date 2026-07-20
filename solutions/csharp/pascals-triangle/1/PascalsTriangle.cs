public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        List<int[]> list = new();
        for (int i = 0; i < rows; i++)
        {
            int[] row = new int[i + 1];
            row[0] = 1;
            for (int j = 0; j < i - 1; j++) row[j + 1] = list.Last()[j] + list.Last()[j + 1];
            row[^1] = 1;
            list.Add(row);
        }
        return list.ToArray();
    }

}