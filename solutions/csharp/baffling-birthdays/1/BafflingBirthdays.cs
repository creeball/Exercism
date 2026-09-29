public static class BafflingBirthdays
{
    private static readonly Random Random = new();
    public static DateOnly[] RandomBirthdates(int numberOfBirthdays) =>
        Enumerable.Range(0, numberOfBirthdays).Select(_ => new DateOnly().AddDays(Random.Next(365))).ToArray();

    public static bool SharedBirthday(DateOnly[] birthdays) =>
        birthdays.DistinctBy(d => (d.Month, d.Day)).Count() != birthdays.Length;

    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays) =>
        Enumerable
            .Range(0, 10000)
            .Count(_ => SharedBirthday(RandomBirthdates(numberOfBirthdays))) / 100.0;
}
