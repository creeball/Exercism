public class BowlingGame
{
    private readonly List<int> _rolls = [];
    private int _extraRolls;
    private int _frames;
    private bool _isFirst = true;
    private bool _isComplete;
    public void Roll(int pins)
    {
        if (pins is < 0 or > 10 || _isComplete) throw new ArgumentException();
        var moreThanTen = _frames >= 10;
        if (!_isFirst)
        {
            if (pins + _rolls.Last() > 10) throw new ArgumentException();
            _frames++;
            _isFirst = true;
        }
        else if (pins == 10) _frames++;
        else _isFirst = false;
        if (moreThanTen)
        {
            _extraRolls--;
            if (_extraRolls == 0) _isComplete = true;
        }
        else if (_frames == 10 && _extraRolls == 0)
        {
            if (pins == 10) _extraRolls = 2;
            else if (pins + _rolls[^1] == 10) _extraRolls = 1;
            else _isComplete = true;
        }
        _rolls.Add(pins);
    }

    public int? Score()
    {
        if (!_isComplete) throw new ArgumentException();
        int score = 0;
        int j = 0;
        for (int i = 0; i < 10; i++)
        {
            int sum = _rolls[j] + _rolls[j + 1];
            bool flag = _rolls[j] == 10;
            score += sum;
            if (flag || sum == 10) score += _rolls[j + 2];
            j += flag ? 1 : 2;
        }
        return score;
    }
}