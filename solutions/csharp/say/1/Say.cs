public static class Say
{
    private static readonly string[] Numbers = 
        [
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        ];

    private static readonly string[] Tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

    private static readonly string[] Units = ["thousand", "million", "billion"];
    
    public static string InEnglish(long number)
    {
        if (number is < 0 or > 999_999_999_999) throw new ArgumentOutOfRangeException();
        if (number == 0) return "zero";
        List<string> words = [];
        var num = number % 1000;
        if (num != 0) words.Add(ThreeDigitsInEnglish(num));
        number /= 1000;
        for (int i = 0; number != 0; i++)
        {
            num = number % 1000;
            if (num != 0) words.Add($"{ThreeDigitsInEnglish(num)} {Units[i]}");
            number /= 1000;
        }
        words.Reverse();
        return string.Join(' ', words);
    }

    private static string ThreeDigitsInEnglish(long number)
    {
        var lastTwoDigits = number % 100;
        var hundredsDigit = number / 100;
        return (hundredsDigit == 0, lastTwoDigits == 0) switch
        {
            (true, false) => TwoDigitsInEnglish(lastTwoDigits),
            (false, true) => $"{Numbers[hundredsDigit]} hundred",
            (false, false) => $"{Numbers[hundredsDigit]} hundred {TwoDigitsInEnglish(lastTwoDigits)}",
            _ => ""
        };
    }

    private static string TwoDigitsInEnglish(long number)
    {
        if (number < 20) return Numbers[number];
        var onesDigit = number % 10;
        return onesDigit == 0 ? $"{Tens[number / 10]}" : $"{Tens[number / 10]}-{Numbers[onesDigit]}";
    }
}