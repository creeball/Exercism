public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup(int month, int year)
{
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime firstDay = new(year, month, 1);
        var offset = (dayOfWeek + 7 - firstDay.DayOfWeek) % 7;
        switch (schedule)
        {
            case Schedule.Teenth:
                return firstDay.AddDays(12 + (offset + 2) % 7);
            case Schedule.First:
                return firstDay.AddDays(offset);
            case Schedule.Second:
                return firstDay.AddDays(offset + 7);
            case Schedule.Third:
                return firstDay.AddDays(offset + 14);
            case Schedule.Fourth:
                return firstDay.AddDays(offset + 21);
            case Schedule.Last:
            default:
                var date = firstDay.AddDays(offset + 28);
                return date.Month == month ? date : date.AddDays(-7);
        }
    }
}