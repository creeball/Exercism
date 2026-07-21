using System.Text;

public class SimpleCipher(string key)
{
    private static readonly Random Rnd = new Random();
    public SimpleCipher() : this(Rnd.GetString("abcdefghijklmnopqrstuvwxyz", 100)) { }

    public string Key { get; set; } = key;

    public string Encode(string plaintext)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            sb.Append((char)((plaintext[i] + Key[i % Key.Length] - 2 * 'a') % 26 + 'a'));
        }
        return sb.ToString();
    }

    public string Decode(string ciphertext)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < ciphertext.Length; i++)
        {
            sb.Append((char)((ciphertext[i] - Key[i % Key.Length] + 26) % 26 + 'a'));
        }
        return sb.ToString();
    }
}