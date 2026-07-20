public static class Tournament
{   
    public class Score
    {
        public int MP;
        public int W;
        public int D;
        public int L;
        public int P => W * 3 + D;
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        Dictionary<string, Score> scores = new Dictionary<string, Score>();
        Record(scores, inStream);
        Print(scores, outStream);
    }
    private enum GameResult
    {
        Win,
        Lose,
        Draw
    }
    public static void Record(Dictionary<string, Score> scores, Stream inStream)
    {
        using StreamReader sr = new StreamReader(inStream);

        while (sr.ReadLine() is { } line)
        {
            string[] cols = line.Split(';');
            switch (cols[2])
            {
                case "win":
                    UpdateScore(cols[0], GameResult.Win);
                    UpdateScore(cols[1], GameResult.Lose);
                    break;
                case "loss":
                    UpdateScore(cols[1], GameResult.Win);
                    UpdateScore(cols[0], GameResult.Lose);
                    break;
                case "draw":
                    UpdateScore(cols[0], GameResult.Draw);
                    UpdateScore(cols[1], GameResult.Draw);
                    break;
            }
        }
        
        void UpdateScore(string teamName, GameResult result)
        {
            if (!scores.TryGetValue(teamName, out Score? value))
            {
                value = new Score();
                scores.Add(teamName, value);
            }
            value.MP++;
            switch (result)
            {
                case GameResult.Win:
                    value.W++;
                    break;
                case GameResult.Lose:
                    value.L++;
                    break;
                case GameResult.Draw:
                    value.D++;
                    break;
            }
        }
    }
    public static void Print(Dictionary<string, Score> scores, Stream outStream)
    {
        using StreamWriter sw = new StreamWriter(outStream);
        var teams = scores
            .OrderByDescending(s => s.Value.P)
            .ThenBy(s => s.Key)
            .ToList();
        
        sw.Write("Team                           | MP |  W |  D |  L |  P");
        if (scores.Count != 0) sw.WriteLine();
        for (int i = 0; i < scores.Count; i++)
        {
            KeyValuePair<string, Score> team = teams[i];
            sw.Write($"{team.Key, -30} | {team.Value.MP, 2} | {team.Value.W, 2} | {team.Value.D, 2} | {team.Value.L, 2} | {team.Value.P, 2}");
            if (i < scores.Count - 1) sw.WriteLine();
        }
    }
}