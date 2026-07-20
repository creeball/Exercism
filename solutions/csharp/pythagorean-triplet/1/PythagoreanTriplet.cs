public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int, int, int)> list = new();
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a; b < sum / 2; b++)
            {
                int c = sum - a - b;
                if (c < b) break;
                if (a * a + b * b == c * c)
                    list.Add((a, b, c));
            }
        }
        return list;
    }
}