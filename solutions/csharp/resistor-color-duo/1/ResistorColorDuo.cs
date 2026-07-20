public static class ResistorColorDuo
{
    enum Colors
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
        white,
    }
    public static int Value(string[] colors)
    {
        return 10 * (int)Enum.Parse<Colors>(colors[0]) + (int)Enum.Parse<Colors>(colors[1]);
    }
}