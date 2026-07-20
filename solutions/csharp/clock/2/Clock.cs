public class Clock
{
    private readonly TimeOnly _time;
    public Clock(int hours, int minutes)
    {
        hours += minutes / 60;
        minutes %= 60;
        if (minutes < 0)
        {
            minutes += 60;
            hours -= 1;
        }
        hours %= 24;
        if (hours < 0) hours += 24;
        _time = new TimeOnly(hours, minutes);
    }
    private Clock(TimeOnly time) =>
        _time = time;
    public Clock Add(int minutesToAdd) =>
        new Clock(_time.AddMinutes(minutesToAdd));
    public Clock Subtract(int minutesToSubtract) =>
        new Clock(_time.AddMinutes(-minutesToSubtract));
    public override string ToString() => 
        _time.ToString();
    public override bool Equals(object? obj) =>
        _time == (obj as Clock)?._time;
    public override int GetHashCode() =>
        _time.GetHashCode();
}