public static class KillerSudokuHelper
{
    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude)
    {
        Stack<int> nums = [];
        return TryCombine(1, size);
        IEnumerable<int[]> TryCombine(int from, int count)
        {
            if (count == 0)
            {
                if (nums.Sum() == sum) yield return nums.Reverse().ToArray();
            }
            else
            {
                for (int i = from; i < 10; i++)
                {
                    if (exclude.Contains(i)) continue;
                    nums.Push(i);
                    foreach (var next in TryCombine(i + 1, count - 1))
                    {
                        yield return next;
                    }
                    nums.Pop();
                }
            }
        }
    }
}
