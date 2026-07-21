using System.Text;
public static class House
{
    private static readonly string[] Subjects =
    [
        "house",
        "malt",
        "rat",
        "cat",
        "dog",
        "cow with the crumpled horn",
        "maiden all forlorn",
        "man all tattered and torn",
        "priest all shaven and shorn",
        "rooster that crowed in the morn",
        "farmer sowing his corn",
        "horse and the hound and the horn"
    ];
    private static readonly string[] Verbs =
    [
        "Jack built",
        "lay in",
        "ate",
        "killed",
        "worried",
        "tossed",
        "milked",
        "kissed",
        "married",
        "woke",
        "kept",
        "belonged to"
    ];
    public static string Recite(int verseNumber)
    {
        StringBuilder sb = new();
        sb.Append("This is");
        while (verseNumber-- > 0) sb.Append($" the {Subjects[verseNumber]} that {Verbs[verseNumber]}");
        sb.Append('.');
        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join(
            Environment.NewLine,
            Enumerable.Range(startVerse, endVerse - startVerse + 1)
                .Select(s => Recite(s)));
    }
}