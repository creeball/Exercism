public static class AtbashCipher
{
    public static string Encode(string plainValue) =>
        string.Concat(plainValue
            .ToLower()
            .Where(char.IsLetterOrDigit)
            .Select(c => char.IsLetter(c) ? (char)('a' + 'z' - c) : c)
            .Select((c, i) => i != 0 && i % 5 == 0 ? $" {c}" : $"{c}"));

    public static string Decode(string encodedValue) =>
        string.Concat(encodedValue
            .Where(char.IsLetterOrDigit)
            .Select(c => char.IsLetter(c) ? (char)('a' + 'z' - c) : c));
}