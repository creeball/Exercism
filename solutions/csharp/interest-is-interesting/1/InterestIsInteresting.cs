static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch
        {
            < 0 => 3.213f,
            < 1000 => 0.5f,
            < 5000 => 1.621f,
            _ => 2.475f
        };
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) * 0.01m;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int count = 0;
        var currentBalance = balance;
        while (currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            count++;
        }
        return count;
    }
}