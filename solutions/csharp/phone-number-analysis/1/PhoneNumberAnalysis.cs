public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phoneNumbers = phoneNumber.Split('-');
        return (phoneNumbers[0] == "212", phoneNumbers[1] == "555", phoneNumbers[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo is { IsNewYork: true, IsFake: true };
    }
}  