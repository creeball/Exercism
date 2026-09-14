using System.Text.Json;
using System.Text.Json.Serialization;

public class RestApi(string database)
{
    private class User
    {
        [JsonPropertyName("name")]    public string Name { get; init; } = "";
        [JsonPropertyName("owes")]    public SortedDictionary<string, double> Owes { get; set; } = new();
        [JsonPropertyName("owed_by")] public SortedDictionary<string, double> OwedBy { get; set; } = new();
        [JsonPropertyName("balance")] public double Balance { get; set; }

        public void Lead(User borrower, double amount)
        {
            Balance += amount;
            borrower.Balance -= amount;
            if (Owes.TryGetValue(borrower.Name, out var owe))
            {
                amount -= owe;
                switch (amount)
                {
                    case < 0:
                        Owes[borrower.Name] = -amount;
                        borrower.OwedBy[Name] = -amount;
                        break;
                    case > 0:
                        Owes.Remove(borrower.Name);
                        OwedBy.Add(borrower.Name, amount);
                        borrower.OwedBy.Remove(Name);
                        borrower.Owes.Add(Name, amount);
                        break;
                    default:
                        Owes.Remove(borrower.Name);
                        borrower.OwedBy.Remove(Name);
                        break;
                }
                return;
            }

            if (!OwedBy.TryAdd(borrower.Name, amount))
            {
                OwedBy[borrower.Name] += amount;
                borrower.Owes[Name] += amount;
            }
            else borrower.Owes.Add(Name, amount);
        }
    }
    
    public class IouRequest
    {
        [JsonPropertyName("lender")]   public string Lender   { get; init; } = "";
        [JsonPropertyName("borrower")] public string Borrower { get; init; } = "";
        [JsonPropertyName("amount")]   public double Amount   { get; init; }
    }
    
    public class UsersRequest { [JsonPropertyName("users")] public List<string> Users { get; init; } = []; }
    public class UserRequest { [JsonPropertyName("user")] public string Name { get; init; } = ""; }
    
    private readonly SortedDictionary<string, User> _users = new((JsonSerializer.Deserialize<List<User>>(database) ?? []).ToDictionary(u => u.Name));
    public string Get(string url, string? payload = null)
    {
        switch (url)
        {
            case "/users":
                if (payload == null) return JsonSerializer.Serialize(_users.Values);
                UsersRequest request = JsonSerializer.Deserialize<UsersRequest>(payload) ?? throw new ArgumentException();
                return JsonSerializer.Serialize(request.Users.Select(u => _users[u]).OrderBy(u => u.Name));
            default:
                throw new ArgumentException();
        }
    }

    public string Post(string url, string payload)
    {
        switch (url)
        {
            case "/add":
                var user = JsonSerializer.Deserialize<UserRequest>(payload) ?? throw new ArgumentException();
                return _users.TryAdd(user.Name, new User { Name = user.Name }) ? JsonSerializer.Serialize(_users[user.Name]) : throw new ArgumentException();
            case "/iou":
                var iou = JsonSerializer.Deserialize<IouRequest>(payload) ?? throw new ArgumentException();
                var (leader, borrower, amount) = (_users[iou.Lender], _users[iou.Borrower], iou.Amount);
                leader.Lead(borrower, amount);
                return JsonSerializer.Serialize(new[] { leader.Name, borrower.Name }.Order().Select(u => _users[u]));
            default:
                throw new ArgumentException();
        }
    }
}
