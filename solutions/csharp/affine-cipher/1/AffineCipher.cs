public static class AffineCipher
{
    private static int GetMMI(int a)
    {
        int i = 1;
        while (a * i % 26 != 1) i++;
        return i;
    }

    private static bool Check(int n) => n % 2 != 0 && n % 13 != 0;
    private static char Encode(char c, int a, int b) => (char)((a * (char.ToLower(c) - 'a') + b) % 26 + 'a');
    public static string Encode(string plainText, int a, int b)
    {
        if (!Check(a)) throw new ArgumentException();
        return string.Join(' ', plainText
            .Where(char.IsLetterOrDigit)
            .Select(c => char.IsLetter(c) ? Encode(c, a, b) : c)
            .Chunk(5)
            .Select(cs => string.Concat(cs)));
    }
    public static char Decode(char c, int a, int b) => (char)((GetMMI(a) * (char.ToLower(c) - 'a' - b) % 26 + 26) % 26 + 'a');
    public static string Decode(string cipheredText, int a, int b)
    {
        if (!Check(a)) throw new ArgumentException();
        return string.Concat(cipheredText
            .Where(char.IsLetterOrDigit)
            .Select(c => char.IsLetter(c) ? Decode(c, a, b) : c));
    }
}
