public static class ResistorColorTrio
{
    private static readonly string[] Colors = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    public static string Label(string[] colors)
    {
        var num = Colors.IndexOf(colors[0]) * 10 + Colors.IndexOf(colors[1]);
        var zeroCount = Colors.IndexOf(colors[2]);
        while (num != 0 && num % 10 == 0)
        {
            num /= 10;
            zeroCount++;
        }
        return $"{num}{(zeroCount % 3) switch {
            1 => "0",
            2 => "00",
            _ => ""
        }}{(zeroCount / 3) switch {
            1 => " kiloohms",
            2 => " megaohms",
            3 => " gigaohms",
            _ => " ohms"}}";
    }
}