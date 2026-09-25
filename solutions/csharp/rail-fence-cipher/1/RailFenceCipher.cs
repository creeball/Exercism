public class RailFenceCipher(int rails)
{
    private readonly int _period = rails * 2 - 2;
    public string Encode(string input) =>
        string.Concat(input
            .Select((c, i) => (c, i))
            .GroupBy(p => GetRail(p.i))
            .SelectMany(g => g.Select(v => v.c)));

    public string Decode(string input)
    {
        var length = input.Length;
        var groups = length / _period;
        var lastGroup = length % _period;
        int[] items = [groups, ..Enumerable.Repeat(groups * 2, rails - 2), groups];
        for (int i = 0; i < lastGroup; i++) items[GetRail(i)]++;
        var lines = items.Select(i =>
            {
                var line = input[..i];
                input = input[i..];
                return line;
            }).ToArray();
        var lengths = Enumerable.Repeat(0, rails).ToArray();
        return string.Concat(Enumerable.Range(0, length).Select(GetRail).Select(i =>
        {
            var c = lines[i][lengths[i]];
            lengths[i]++;
            return c;
        }));
    }

    private int GetRail(int i)
    {
        i %= _period;
        return i < rails ? i : _period - i;
    }
}