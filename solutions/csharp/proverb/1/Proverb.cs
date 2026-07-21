public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        List<string> list = new();
        for (int i = 1; i < subjects.Length; i++)
        {
            list.Add($"For want of a {subjects[i - 1]} the {subjects[i]} was lost.");
        }
        if (subjects.Length > 0) list.Add($"And all for the want of a {subjects[0]}.");
        return list.ToArray();
    }
}