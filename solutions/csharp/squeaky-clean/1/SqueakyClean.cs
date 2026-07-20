public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new System.Text.StringBuilder(identifier.Length);
        bool capitalizeNext = false;
        foreach (char c in identifier)
        {
            if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == ' ')
            {
                sb.Append('_');
            }
            else if (c == '-')
            {
                capitalizeNext = true;
            }
            else if (!char.IsLetter(c) || c is >= 'α' and <= 'ω') {}
            else
            {
                if (capitalizeNext)
                {
                    sb.Append(char.ToUpperInvariant(c));
                    capitalizeNext = false;
                }
                else
                {
                    sb.Append(c);
                }
            }
        }
        return sb.ToString();
    }
}