public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        return string.Concat(phrase.Split(' ', '-', '_').Where(s => s != "").Select(s => char.ToUpper(s[0])));
    }
}