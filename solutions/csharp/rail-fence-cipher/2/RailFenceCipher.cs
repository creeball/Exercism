public class RailFenceCipher(int rails)
{
    private readonly int _period = rails * 2 - 2;
    private int[] Order(int length) => Enumerable.Range(0, length).OrderBy(GetRail).ToArray();

    public string Encode(string input) => string.Concat(Order(input.Length).Select(i => input[i]));

    public string Decode(string input)
    {
        var order = Order(input.Length);
        var result = new char[input.Length];
        for (var k = 0; k < input.Length; k++) result[order[k]] = input[k];
        return new string(result);
    }

    private int GetRail(int i)
    {
        i %= _period;
        return i < rails ? i : _period - i;
    }
}