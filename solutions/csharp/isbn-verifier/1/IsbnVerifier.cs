using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        Match match = new Regex(@"^(\d-\d{3}-\d{5}-|\d{9})(\d|X)$").Match(number);
        if (!match.Success) return false;
        char lastDigit = match.Groups[2].Value[0];
        List<int> digits = match.Groups[1].Value.Where(char.IsDigit).Select(c => c - '0').ToList();
        digits.Add(lastDigit == 'X' ? 10 : lastDigit - '0');
        digits.Reverse();
        return digits.Select((n, i) => n * (i + 1)).Sum() % 11 == 0;
    }
}