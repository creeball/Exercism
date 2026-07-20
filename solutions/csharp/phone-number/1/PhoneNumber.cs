using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        Regex regex = new(@"^(?:\+?1(?:[-.]?| *))?((?:\([2-9]\d\d\)|[2-9]\d\d)(?:[-.]?| *)[2-9]\d\d(?:[-.]?| *)\d{4}) *$");
        Match match = regex.Match(phoneNumber);
        return match.Success ? string.Concat(match.Groups[1].Value.Where(char.IsDigit)) : throw new ArgumentException();
    }
}