using System.Text;

public static class FoodChain
{
    private static readonly string[] Things = 
    [
        "fly",
        "spider",
        "bird",
        "cat",
        "dog",
        "goat",
        "cow",
        "horse"
    ];
    
    private static readonly string[] SecondLine = 
    [
        "It wriggled and jiggled and tickled inside her.", 
        "How absurd to swallow a bird!", 
        "Imagine that, to swallow a cat!", 
        "What a hog, to swallow a dog!", 
        "Just opened her throat and swallowed a goat!", 
        "I don't know how she swallowed a cow!"
    ];
    
    public static string Recite(int verseNumber)
    {
        StringBuilder sb = new();
        sb.AppendLine($"I know an old lady who swallowed a {Things[verseNumber - 1]}.");
        if (verseNumber == 8)
        {
            sb.Append("She's dead, of course!");
            return sb.ToString();
        }
        if (verseNumber >= 2) sb.AppendLine(SecondLine[verseNumber - 2]);
        while (verseNumber > 1)
        {
            sb.Append($"She swallowed the {Things[verseNumber - 1]} to catch the {Things[verseNumber - 2]}");
            if (verseNumber == 3) sb.Append(" that wriggled and jiggled and tickled inside her");
            sb.AppendLine(".");
            verseNumber--;
        }
        sb.Append("I don't know why she swallowed the fly. Perhaps she'll die.");
        return sb.ToString();
    }
    
    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join("\n\n", Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(i => Recite(i)));
    }
}