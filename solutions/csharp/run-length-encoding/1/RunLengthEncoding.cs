using System.Text;

public static class RunLengthEncoding
{
    private record CharCount(char Char)
    {
        public char Char { get; } = Char;
        public int Count { get; set; } = 1;
    }
    public static string Encode(string input)
    {
        List<CharCount> chars = [];
        foreach (var c in input)
        {
            if (chars.Count != 0 && chars.Last().Char == c) chars.Last().Count++;
            else chars.Add(new CharCount(c));
        }
        return string.Concat(chars.Select(c => c.Count == 1 ? $"{c.Char}" : $"{c.Count}{c.Char}"));
    }

    public static string Decode(string input)
    {
        StringBuilder sb = new();
        int counter = 0;
        foreach (var c in input)
        {
            if (char.IsDigit(c)) counter = counter * 10 + (c - '0');
            else
            {
                sb.Append(new string(c, counter == 0 ? 1 : counter));
                counter = 0;
            }
        }

        return sb.ToString();
    }
}
