public class Robot
{
    private static List<string> _names = [];
    private static readonly Random Random = new Random();
    public string? Name
    {
        get;
        private set
        {
            if (field != null)
            {
                _names.Remove(field);
            }
            if (value != null)
            {
                _names.Add(value);
            }
            field = value;
        }
    }

    public Robot()
    {
        Reset();
    }
    public void Reset()
    {
        string? name;
        do {
            name = $"{(char)Random.Next('A', 'Z' + 1)}{(char)Random.Next('A', 'Z' + 1)}{Random.Next(1000):D3}";
        } while (_names.Contains(name));
        Name = name;
    }
}