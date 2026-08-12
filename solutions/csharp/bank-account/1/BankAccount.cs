public class BankAccount
{
    private readonly Lock _lock = new();
    private bool _isOpen;
    public void Open()
    {
        lock (_lock)
        {
            if (_isOpen) throw new InvalidOperationException();
            _isOpen = true;
            Balance = 0;
        }
    }

    public void Close()
    {
        lock (_lock)
        {
            if (!_isOpen) throw new InvalidOperationException();
            _isOpen = false;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (_lock)
            {
                return !_isOpen ? throw new InvalidOperationException() : field;
            }
        }
        private set
        {
            lock (_lock)
            {
                field = (value < 0) ? throw new InvalidOperationException() : value;
            }
        }
    }

    public void Deposit(decimal change)
    {
        lock (_lock)
        {
            if (change < 0 || !_isOpen) throw new InvalidOperationException();
            Balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        lock (_lock)
        {
            if (change < 0 || !_isOpen) throw new InvalidOperationException();
            Balance -= change;
        }
    }
}
