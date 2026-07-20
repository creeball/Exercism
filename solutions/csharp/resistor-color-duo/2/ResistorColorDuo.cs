public static class ResistorColorDuo
{
    private static readonly string[] Colors = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    public static int Value(string[] colors)
    {
        return 10 * Colors.IndexOf(colors[0]) + Colors.IndexOf(colors[1]);
    }
}