static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return DateTime.Compare(DateTime.Now, appointmentDate) > 0;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        return "You have an appointment on " + appointmentDate.ToString("G") + ".";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}
