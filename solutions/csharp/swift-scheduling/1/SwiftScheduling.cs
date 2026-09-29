public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description)
    {
        switch (description)
        {
            case "NOW": return meetingStart.AddHours(2);
            case "ASAP":
                return new DateTime(DateOnly.FromDateTime(meetingStart), new TimeOnly())
                    .AddHours(meetingStart.Hour < 13 ? 17 : 37);
            case "EOW":
                var flag = meetingStart.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday;
                return new DateTime(DateOnly.FromDateTime(meetingStart), new TimeOnly(flag ? 17 : 20, 0))
                    .AddDays((flag ? 5 : 7) - (int)meetingStart.DayOfWeek);
            default:
                if (description.EndsWith('M'))
                {
                    var month = int.Parse(description[..^1]);
                    var date = new DateTime(
                        new DateOnly(meetingStart.Month < month ? meetingStart.Year : meetingStart.Year + 1, month, 1),
                        new TimeOnly(8, 0));
                    return date.DayOfWeek switch
                    {
                        DayOfWeek.Saturday => date.AddDays(2),
                        DayOfWeek.Sunday => date.AddDays(1),
                        _ => date
                    };
                }
                if (description.StartsWith('Q'))
                {
                    var month = int.Parse(description[1..]) * 3;
                    var date = new DateTime(
                        new DateOnly(meetingStart.Month <= month ? meetingStart.Year : meetingStart.Year + 1, month, 1)
                            .AddMonths(1).AddDays(-1),
                        new TimeOnly(8, 0));
                    return date.DayOfWeek switch
                    {
                        DayOfWeek.Sunday => date.AddDays(-2),
                        DayOfWeek.Saturday => date.AddDays(-1),
                        _ => date
                    };
                }
                return meetingStart;
        }
    }
}
