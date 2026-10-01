double interest_rate(const double &balance)
{
    if (balance < 0)    return 3.213;
    if (balance < 1000) return 0.500;
    if (balance < 5000) return 1.621;
    return 2.475;
}

double yearly_interest(const double &balance)
{
    return balance * interest_rate(balance) * 0.01;
}

double annual_balance_update(const double &balance)
{
    return balance + yearly_interest(balance);
}

int years_until_desired_balance(double balance, const double &target_balance)
{
    int years = 0;
    while (balance < target_balance)
    {
        years++;
        balance = annual_balance_update(balance);
    }
    return years;
}