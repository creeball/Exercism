public static partial class LineUp
{
    public static string Format(string name, int number) =>
        $"{name}, you are the {number}{(number % 10) switch
        {
            1 => number % 100 == 11 ? "th" : "st",
            2 => number % 100 == 12 ? "th" : "nd",
            3 => number % 100 == 13 ? "th" : "rd",
            _ => "th"
        }
    } customer we serve today. Thank you!";
}