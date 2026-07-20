[Flags]
public enum Allergen
{
    Eggs = 0x1,
    Peanuts = 0x2,
    Shellfish = 0x4,
    Strawberries = 0x8,
    Tomatoes = 0x10,
    Chocolate = 0x20,
    Pollen = 0x40,
    Cats = 0x80
}

public class Allergies(int mask)
{
    private Allergen _allergen = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen) => _allergen.HasFlag(allergen);

    public Allergen[] List() => Enum.GetValues<Allergen>().Where(IsAllergicTo).ToArray();
}