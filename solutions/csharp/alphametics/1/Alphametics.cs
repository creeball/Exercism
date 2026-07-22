public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        var split = equation.Split(" == ");
        var result = split[1].Reverse().ToArray();
        var strs = split[0].Split(" + ");
        bool[] isUsed = new bool[10];
        int maxLength = strs.Max(s => s.Length);
        HashSet<char> leadingLetters = [result[^1]];
        foreach (var str in strs) leadingLetters.Add(str[0]);
        List<List<(char Key, int Value)>> letterList =
            Enumerable.Range(0, maxLength)
                .Select(col => strs
                    .Where(s => s.Length > col)
                    .Select(s => s[^(col + 1)])
                    .GroupBy(c => c)
                    .Select(g => (g.Key, g.Count()))
                    .ToList())
                .ToList();
        Dictionary<char, int> letterValues = new();
        return !SolveColumn() ? throw new ArgumentException() : letterValues;
        bool SolveColumn(int col = 0, int carried = 0)
        {
            if (col == Math.Max(letterList.Count, result.Length)) return carried == 0;
            return TrySetValue(col, 0, carried);
        }
        bool TrySetValue(int col = 0, int index = 0, int carried = 0)
        {
            if (col >= letterList.Count)
            {
                if (col >= result.Length) return carried == 0;
                return Check(col, carried);
            }
            if (index >= letterList[col].Count) return Check(col, carried);
            if (letterValues.ContainsKey(letterList[col][index].Key)) return TrySetValue(col, index + 1, carried);
            for (int i = 0; i < 10; i++)
            {
                if (isUsed[i] || (i == 0 && leadingLetters.Contains(letterList[col][index].Key))) continue;
                isUsed[i] = true;
                letterValues.Add(letterList[col][index].Key, i);
                if (TrySetValue(col, index + 1, carried)) return true;
                isUsed[i] = false;
                letterValues.Remove(letterList[col][index].Key);
            }
            return false;
        }
        bool Check(int col, int carried = 0)
        {
            int sum = carried;
            if (col < letterList.Count)
                sum += letterList[col].Sum(letter => letterValues[letter.Key] * letter.Value);
            int value = sum % 10;
            carried = sum / 10;
            if (col >= result.Length) return value == 0;
            if (!letterValues.TryAdd(result[col], value))
            {
                if (letterValues[result[col]] != value) return false;
            }
            else
            {
                if (isUsed[value]) return false;
                if (value == 0 && leadingLetters.Contains(result[col])) return false;
                isUsed[value] = true;
                if (SolveColumn(col + 1, carried)) return true;
                letterValues.Remove(result[col]);
                isUsed[value] = false;
                return false;
            }
            return SolveColumn(col + 1, carried);
        }
    }
}