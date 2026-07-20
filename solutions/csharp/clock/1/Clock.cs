public class Clock
{
    private readonly TimeOnly _time;

    private Clock(TimeOnly time)
    {
        _time = time;
    }
    
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

    public Clock Add(int minutesToAdd)
    {
        return new Clock(_time.AddMinutes(minutesToAdd));
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_time.AddMinutes(-minutesToSubtract));
    }

    public override string ToString()
    {
        return _time.ToString();
    }

    public override bool Equals(object? clock)
    {
        return _time.Equals((clock as Clock)?._time);
    }

    public override int GetHashCode()
    {
        return _time.GetHashCode();
    }
}