public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        Dictionary<int, int> diceDict = [];
        foreach (var point in dice)
        {
            if (!diceDict.TryAdd(point, 1)) diceDict[point]++;
        }

        return category switch
        {
            YachtCategory.Ones => diceDict.TryGetValue(1, out var value) ? value * 1 : 0,
            YachtCategory.Twos => diceDict.TryGetValue(2, out var value) ? value * 2 : 0,
            YachtCategory.Threes => diceDict.TryGetValue(3, out var value) ? value * 3 : 0,
            YachtCategory.Fours => diceDict.TryGetValue(4, out var value) ? value * 4 : 0,
            YachtCategory.Fives => diceDict.TryGetValue(5, out var value) ? value * 5 : 0,
            YachtCategory.Sixes => diceDict.TryGetValue(6, out var value) ? value * 6 : 0,
            YachtCategory.FullHouse => diceDict.Count == 2 && diceDict.ContainsValue(2) ? diceDict.Sum(v => v.Value * v.Key) : 0,
            YachtCategory.FourOfAKind => diceDict.Where(v => v.Value >= 4).Select(v => v.Key * 4).Sum(),
            YachtCategory.LittleStraight => diceDict.Count == 5 && !diceDict.ContainsKey(6) ? 30 : 0,
            YachtCategory.BigStraight => diceDict.Count == 5 && !diceDict.ContainsKey(1) ? 30 : 0,
            YachtCategory.Choice => diceDict.Sum(v => v.Value * v.Key),
            YachtCategory.Yacht => diceDict.Count == 1 ? 50 : 0,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

