public static class ResistorColor
{
    enum BandColors
    {
        black,
        brown,
        red,
        orange,
        yellow,
        green,
        blue,
        violet,
        grey,
        white
    }
    public static int ColorCode(string color) => (int)Enum.Parse<BandColors>(color);

    public static string[] Colors()
    {
        return Enum.GetNames<BandColors>();
    }
}