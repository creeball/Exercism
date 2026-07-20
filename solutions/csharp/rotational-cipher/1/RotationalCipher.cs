using System.Text;
public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        shiftKey %= 26;
        StringBuilder sb = new();
        foreach (char c in text)
        {
            if (char.IsUpper(c))
                sb.Append((char)((c - 'A' + shiftKey) % 26 + 'A'));
            else if (char.IsLower(c))
                sb.Append((char)((c - 'a' + shiftKey) % 26 + 'a'));
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
}