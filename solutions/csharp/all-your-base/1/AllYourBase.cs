public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2) throw new ArgumentException();
        int num = inputDigits.Aggregate(0, (value, digit) => digit >= 0 && digit < inputBase ? value * inputBase + digit : throw new ArgumentException());
        Stack<int> outputDigits = new();
        do outputDigits.Push(num % outputBase);
        while ((num /= outputBase) > 0);
        return outputDigits.ToArray();
    }
}