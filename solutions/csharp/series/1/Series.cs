public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0) throw new ArgumentException();
        List<string> strs = new();
        for (int i = 0; i + sliceLength - 1 < numbers.Length; i++) strs.Add(numbers[i..(i + sliceLength)]);
        return strs.Count == 0 ? throw new ArgumentException() : strs.ToArray();
    }
}