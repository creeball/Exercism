public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string str = number.ToString();
        int sum = 0;
        foreach (var c in str)
        {
            sum += Pow(c - '0', str.Length);
        }

        return sum == number;

        int Pow(int x, int n)
        {
            int result = 1;
            while (n-- > 0) result *= x;
            return result;
        }
    }
}