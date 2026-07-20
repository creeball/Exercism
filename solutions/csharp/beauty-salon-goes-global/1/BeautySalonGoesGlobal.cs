using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static readonly bool isWindows = OperatingSystem.IsWindows();
    
    public static DateTime ShowLocalTime(DateTime dateTimeUtc) 
    => dateTimeUtc.ToLocalTime();
    
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var dateTime = DateTime.Parse(appointmentDateDescription);
        var timeZoneInfo = GetTimeZoneInfo(location);
        return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) 
    => alertLevel switch {
        AlertLevel.Early => appointment.AddDays(-1),
        AlertLevel.Standard => appointment.AddHours(-1.75),
        AlertLevel.Late => appointment.AddMinutes(-30),
        _ => throw new Exception()
    };

    public static bool HasDaylightSavingChanged(DateTime dateTime, Location location)
    {
        var timeZoneInfo = GetTimeZoneInfo(location);
        var sevenDaysEarlier = dateTime.AddDays(-7);
        return (timeZoneInfo.IsDaylightSavingTime(dateTime) != timeZoneInfo.IsDaylightSavingTime(sevenDaysEarlier));
    }

    public static DateTime NormalizeDateTime(string dataTimeText, Location location)
    {
        var cultureInfo = GetLocationCultureInfo(location);
        var success = DateTime.TryParse(dataTimeText, cultureInfo, DateTimeStyles.None, out var dateTime);
        return success ? dateTime : new(1, 1, 1);
    }

    private static DateTimeFormatInfo GetDateTimeFormatInfo(Location location) 
    => GetLocationCultureInfo(location).DateTimeFormat;
    
    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    => TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location));
    
    private static CultureInfo GetLocationCultureInfo(Location location)
    => CultureInfo.GetCultureInfo(
        location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(),
        });

    private static string GetTimeZoneID(Location location) => location switch
    {
        Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
        Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
        Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new ArgumentOutOfRangeException(),
    };
}