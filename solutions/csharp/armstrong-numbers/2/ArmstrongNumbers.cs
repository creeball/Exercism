public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string str = number.ToString();
        return str.Select(c => Pow(c - '0', str.Length)).Sum() == number;
        int Pow(int x, int n)
        {
            int result = 1;
            while (n-- > 0) result *= x;
            return result;
        }
    }
}