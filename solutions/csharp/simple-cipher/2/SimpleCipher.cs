public class SimpleCipher(string key)
{
    private static readonly Random Rnd = new Random();
    public SimpleCipher() : this(Rnd.GetString("abcdefghijklmnopqrstuvwxyz", 100)) { }

    public string Key { get; } = key;

    public string Encode(string plaintext) =>
        string.Concat(plaintext.Select((c, i) => Shift(c, Key[i % Key.Length] - 'a')));

    public string Decode(string ciphertext) =>
        string.Concat(ciphertext.Select((c, i) => Shift(c, 'a' - Key[i % Key.Length])));

    private static char Shift(char c, int offset) => (char)((c - 'a' + offset + 26) % 26 + 'a');
}