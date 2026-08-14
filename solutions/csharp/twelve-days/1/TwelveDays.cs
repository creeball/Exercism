public static class TwelveDays
{
    private static readonly string[] Verses =
    [
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    ];

    private static readonly string[] Numbers =
    [
        "first",
        "second",
        "third",
        "fourth",
        "fifth",
        "sixth",
        "seventh",
        "eighth",
        "ninth",
        "tenth",
        "eleventh",
        "twelfth"
    ];
    
    public static string Recite(int verseNumber)
    {
        string head = $"On the {Numbers[verseNumber - 1]} day of Christmas my true love gave to me: ";
        List<string> sentences = [];
        int counter = verseNumber;
        while (--counter > 0) sentences.Add(Verses[counter]);
        sentences.Add(verseNumber == 1 ? Verses[0] : $"and {Verses[0]}");
        return $"{head}{string.Join(", ", sentences)}.";
    }

    public static string Recite(int startVerse, int endVerse) => 
        string.Join("\n", Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(x => Recite(x)));
}