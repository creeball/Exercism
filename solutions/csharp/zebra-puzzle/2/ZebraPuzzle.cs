public enum Color { Red , Green , Ivory , Yellow , Blue }
public enum Nationality { Englishman , Spaniard , Ukrainian , Japanese , Norwegian }
public enum Pet { Dog , Snails , Fox , Horse , Zebra }
public enum Drink { Coffee , Tea , Milk , OrangeJuice , Water }
public enum Smoke { OldGold , Kools , Chesterfields , LuckyStrike , Parliaments }

public static class ZebraPuzzle
{
    private static readonly (int[] color, int[] nat, int[] drink, int[] smoke, int[] pet) Solved = (
            from color in Permutations(5)
            where color[(int)Color.Green] == color[(int)Color.Ivory] + 1
            from nat in Permutations(5)
            where nat[(int)Nationality.Norwegian] == 0 &&
                  Math.Abs(nat[(int)Nationality.Norwegian] - color[(int)Color.Blue]) == 1 &&
                  nat[(int)Nationality.Englishman] == color[(int)Color.Red]
            from drink in Permutations(5)
            where drink[(int)Drink.Coffee] == color[(int)Color.Green] &&
                  drink[(int)Drink.Tea] == nat[(int)Nationality.Ukrainian] &&
                  drink[(int)Drink.Milk] == 2
            from pet in Permutations(5)
            where pet[(int)Pet.Dog] == nat[(int)Nationality.Spaniard]
            from smoke in Permutations(5)
            where smoke[(int)Smoke.OldGold] == pet[(int)Pet.Snails] &&
                  smoke[(int)Smoke.Kools] == color[(int)Color.Yellow] &&
                  Math.Abs(smoke[(int)Smoke.Chesterfields] - pet[(int)Pet.Fox]) == 1 &&
                  Math.Abs(smoke[(int)Smoke.Kools] - pet[(int)Pet.Horse]) == 1 &&
                  smoke[(int)Smoke.Parliaments] == nat[(int)Nationality.Japanese] &&
                  smoke[(int)Smoke.LuckyStrike] == drink[(int)Drink.OrangeJuice]
            select (color, nat, drink, smoke, pet))
            .Single();

    public static Nationality DrinksWater() => (Nationality)Solved.nat.IndexOf(Solved.drink[(int)Drink.Water]);

    public static Nationality OwnsZebra() => (Nationality)Solved.nat.IndexOf(Solved.pet[(int)Pet.Zebra]);

    private static IEnumerable<int[]> Permutations(int n)
    {
        var used = new bool[n];
        var positions = new int[n];

        return Fill(0);

        IEnumerable<int[]> Fill(int depth)
        {
            if (depth == n)
            {
                yield return (int[])positions.Clone();
                yield break;
            }

            for (var i = 0; i < n; i++)
            {
                if (used[i]) continue;
                used[i] = true;
                positions[depth] = i;

                foreach (var next in Fill(depth + 1)) yield return next;

                used[i] = false;
            }
        }
    }
}
