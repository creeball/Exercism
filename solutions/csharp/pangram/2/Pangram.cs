public static class Pangram
{
    public static bool IsPangram(string input)
    {
        return input.ToLower().Where(char.IsLetter).Distinct().Count() == 26;
    }
}