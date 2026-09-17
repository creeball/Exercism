public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var evaluated = hands.Select(hand => (hand, key: Evaluate(hand))).ToList();
        var best = evaluated.Max(e => e.key);
        return evaluated.Where(e => e.key == best).Select(e => e.hand);
    }

    private static (int Category, long Tiebreak) Evaluate(string hand)
    {
        (int[] ranks, bool isFlush) = ParseHand(hand);
        int straightHigh = StraightHigh(ranks);
        
        var groups = ranks
            .GroupBy(rank => rank)
            .Select(g => (Rank: g.Key, Count: g.Count()))
            .OrderByDescending(g => g.Count)
            .ThenByDescending(g => g.Rank)
            .ToList();

        int[] counts = groups.Select(g => g.Count).ToArray();

        int category;
        if (straightHigh > 0) category = isFlush ? 9 : 5;
        else if (isFlush) category = 6;
        else if (counts[0] == 4) category = 8;
        else if (counts[0] == 3 && counts[1] == 2) category = 7;
        else if (counts[0] == 3) category = 4;
        else if (counts[0] == 2 && counts[1] == 2) category = 3;
        else if (counts[0] == 2) category = 2;
        else category = 1;
        
        int[] tiebreak = straightHigh > 0
            ? [straightHigh, straightHigh - 1, straightHigh - 2, straightHigh - 3, straightHigh - 4]
            : groups.SelectMany(g => Enumerable.Repeat(g.Rank, g.Count)).ToArray();

        return (category, Encode(tiebreak));
    }

    private static (int[] Ranks, bool IsFlush) ParseHand(string hand)
    {
        string[] cards = hand.Split(' ');
        int[] ranks = new int[cards.Length];
        HashSet<char> suits = [];

        for (int i = 0; i < cards.Length; i++)
        {
            string face = cards[i][..^1];
            suits.Add(cards[i][^1]);

            ranks[i] = face switch
            {
                "A" => 14,
                "K" => 13,
                "Q" => 12,
                "J" => 11,
                _ => int.Parse(face),
            };
        }

        Array.Sort(ranks);
        Array.Reverse(ranks);
        return (ranks, suits.Count == 1);
    }
    
    private static int StraightHigh(int[] ranks)
    {
        bool consecutive = true;
        for (int i = 0; i < ranks.Length - 1; i++)
        {
            if (ranks[i] - 1 != ranks[i + 1])
            {
                consecutive = false;
                break;
            }
        }

        if (consecutive) return ranks[0];

        if (ranks[0] == 14 && ranks[1] == 5 && ranks[2] == 4 && ranks[3] == 3 && ranks[4] == 2)
            return 5;   // A 当 1 用

        return 0;
    }
    
    private static long Encode(int[] values)
    {
        long result = 0;
        foreach (int value in values)
            result = result * 15 + value;
        return result;
    }
}