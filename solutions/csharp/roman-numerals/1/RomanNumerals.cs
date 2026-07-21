using System.Text;
public static class RomanNumeralExtension
{
    private static readonly (string Numeral, int Value)[] RomanNumerals =
    [
        ("M", 1000),
        ("CM", 900),
        ("D", 500),
        ("CD", 400),
        ("C", 100),
        ("XC", 90),
        ("L", 50),
        ("XL", 40),
        ("X", 10),
        ("IX", 9),
        ("V", 5),
        ("IV", 4),
        ("I", 1)
    ];
    public static string ToRoman(this int value)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var romanNumeral in RomanNumerals)
        {
            sb.Append(string.Concat(Enumerable.Repeat(romanNumeral.Numeral, value / romanNumeral.Value)));
            value %= romanNumeral.Value;
        }
        return sb.ToString();
    }
}