public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var text = string.Concat(plaintext.ToLower().Where(char.IsLetterOrDigit));
        int cols = 0;
        while (cols * cols < text.Length) cols++;
        List<string> lines = new();
        for (int i = 0; i < text.Length; i += cols)
        {
            lines.Add(text
                .Substring(i, Math
                    .Min(cols, text.Length - i))
                .PadRight(cols));
        }   
        return string
            .Join(" ", Enumerable
                .Range(0, cols)
                .Select(col => string
                    .Concat(lines
                        .Select(row => row[col])))
                .ToList());
    }
}