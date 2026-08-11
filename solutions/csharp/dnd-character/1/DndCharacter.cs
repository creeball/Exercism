public class DndCharacter
{
    public int Strength { get; } = Ability();
    public int Dexterity { get; } = Ability();
    public int Constitution { get; } = Ability();
    public int Intelligence { get; } = Ability();
    public int Wisdom { get; } = Ability();
    public int Charisma { get; } = Ability();
    public int Hitpoints { get; }
    private static Random Random { get; } = new();

    private DndCharacter() => Hitpoints = 10 + Modifier(Constitution);

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() => Enumerable.Range(0, 4).Select(_ => Random.Next(1, 7)).Order().Skip(1).Sum();

    public static DndCharacter Generate() => new();
}