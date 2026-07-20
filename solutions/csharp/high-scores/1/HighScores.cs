public class HighScores(List<int> list)
{
    private readonly List<int> _list = list;

    public List<int> Scores() => _list;

    public int Latest() => _list.Last();

    public int PersonalBest() => _list.Max();

    public List<int> PersonalTopThree() => _list.OrderByDescending(i => i).Take(3).ToList();
}