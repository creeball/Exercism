public enum Color { Red , Green , Ivory , Yellow , Blue }
public enum Nationality { Englishman , Spaniard , Ukrainian , Japanese , Norwegian }
public enum Pet { Dog , Snails , Fox , Horse , Zebra }
public enum Drink { Coffee , Tea , Milk , OrangeJuice , Water }
public enum Smoke { OldGold , Kools , Chesterfields , LuckyStrike , Parliaments }

public static class ZebraPuzzle
{
    private static readonly (Color[] color, Nationality[] nat, Drink[] drink, Smoke[] smoke, Pet[] pet) Solved = (
            from color in Permutations<Color>()
            where color.IndexOf(Color.Green) == color.IndexOf(Color.Ivory) + 1
            from nat in Permutations<Nationality>()
            where nat.IndexOf(Nationality.Norwegian) == 0 &&
                  Math.Abs(nat.IndexOf(Nationality.Norwegian) - color.IndexOf(Color.Blue)) == 1 &&
                  nat.IndexOf(Nationality.Englishman) == color.IndexOf(Color.Red)
            from drink in Permutations<Drink>()
            where drink.IndexOf(Drink.Coffee) == color.IndexOf(Color.Green) &&
                  drink.IndexOf(Drink.Tea) == nat.IndexOf(Nationality.Ukrainian) &&
                  drink.IndexOf(Drink.Milk) == 2
            from pet in Permutations<Pet>()
            where pet.IndexOf(Pet.Dog) == nat.IndexOf(Nationality.Spaniard)
            from smoke in Permutations<Smoke>()
            where smoke.IndexOf(Smoke.OldGold) == pet.IndexOf(Pet.Snails) &&
                  smoke.IndexOf(Smoke.Kools) == color.IndexOf(Color.Yellow) &&
                  Math.Abs(smoke.IndexOf(Smoke.Chesterfields) - pet.IndexOf(Pet.Fox)) == 1 &&
                  Math.Abs(smoke.IndexOf(Smoke.Kools) - pet.IndexOf(Pet.Horse)) == 1 &&
                  smoke.IndexOf(Smoke.Parliaments) == nat.IndexOf(Nationality.Japanese) &&
                  smoke.IndexOf(Smoke.LuckyStrike) == drink.IndexOf(Drink.OrangeJuice)
            select (color, nat, drink, smoke, pet))
            .Single();
    public static Nationality DrinksWater() => Solved.nat[Solved.drink.IndexOf(Drink.Water)];

    public static Nationality OwnsZebra() => Solved.nat[Solved.pet.IndexOf(Pet.Zebra)];

    private static IEnumerable<T[]> Permutations<T>(int n = 5) where T : struct, Enum
    {
        var values = Enum.GetValues<T>();
        var used = new bool[n];
        var permutation = new T[n];

        return Set(0);

        IEnumerable<T[]> Set(int index)
        {
            for (var i = 0; i < n; i++)
            {
                if (used[i]) continue;
                used[i] = true;
                permutation[index] = values[i];

                if (index == n - 1) yield return (T[])permutation.Clone();
                else foreach (var next in Set(index + 1)) yield return next;

                used[i] = false;
            }
        }
    }
}