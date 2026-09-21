public static class PigLatin
{
    public static string Translate(string line) => string.Join(' ', line.Split(' ').Select(TranslateWord));

    private static string TranslateWord(string word)
    {
        if (word == "") return word;
        
        if (word.First() is 'a' or 'e' or 'i' or 'o' or 'u' ||
            (word.Length >= 2 && word[..2] is "xr" or "yt")) return $"{word}ay";
        
        for (int i = 1; i < word.Length; i++)
        {
            switch (word[i])
            {
                case 'u':
                    if (word[i - 1] is 'q') i++;
                    return $"{word[i..]}{word[..i]}ay";
                case 'a' or 'e' or 'i' or 'o' or 'y':
                    return $"{word[i..]}{word[..i]}ay";
            }
        }

        return $"{word}ay";
    }
}