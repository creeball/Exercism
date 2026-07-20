public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked(@base * multiplier).ToString();
        }
        catch (OverflowException e)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float num = @base * multiplier;
        return float.IsPositiveInfinity(num) ? "*** Too Big ***" : num.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return checked(@salaryBase * multiplier).ToString();
        }
        catch (OverflowException e)
        {
            return "*** Much Too Big ***";
        }
    }
}