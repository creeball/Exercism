using System;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        List<string> pileCentral = [];
        var total = playerA.Length + playerB.Length;
        Queue<string> pileA = new(playerA);
        Queue<string> pileB = new(playerB);
        HashSet<(string, string)> history = [];
        var (pA, pB) = (pileA, pileB);
        int tricks = 0;
        int cards = 0;
        while (true)
        {
            if (!history.Add((ToKey(pA.ToArray()), ToKey(pB.ToArray()))))
                return new GameResult(GameStatus.Loop, tricks, cards);
            if (pileA.Count == total || pileB.Count == total) return new GameResult(GameStatus.Finished, tricks, cards);
            if (!TryPlay(out var card)) continue;
            Turn();
            if (NeedPay(card, out var amount)) Pay(amount);
        }

        bool TryPlay(out string card)
        {
            var canPlay = pileA.TryDequeue(out var value);
            card = value ?? "";
            if (canPlay)
            {
                pileCentral.Add(card);
                cards++;
            }
            else
            {
                Turn();
                TakeAll();
            }
            return canPlay;
        }

        void Turn() => (pileA, pileB) = (pileB, pileA);

        void Pay(int count)
        {
            while (true)
            {
                if (!TryPlay(out var card)) break;
                if (NeedPay(card, out var amount))
                {
                    Turn();
                    Pay(amount);
                    break;
                }
                if (--count != 0) continue;
                Turn();
                TakeAll();
                break;
            }
        }

        void TakeAll()
        {
            tricks++;
            foreach (var c in pileCentral) pileA.Enqueue(c);
            pileCentral.Clear();
        }
    }

    private static bool NeedPay(string card, out int amount)
    {
        amount = card switch
        {
            "J" => 1,
            "Q" => 2,
            "K" => 3,
            "A" => 4,
            _ => 0
        };
        return amount > 0;
    }
    private static string ToKey(string[] cards) => string.Concat(cards.Select(c => int.TryParse(c, out _) ? "0" : c));
}
