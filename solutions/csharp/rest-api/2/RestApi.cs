using System.Text.Json;
using System.Text.Json.Serialization;

public class RestApi(string database)
{
    private class User
    {
        [JsonPropertyName("name")]    public string Name { get; init; } = "";
        [JsonPropertyName("owes")]    public SortedDictionary<string, double> Owes { get; set; } = new();
        [JsonPropertyName("owed_by")] public SortedDictionary<string, double> OwedBy { get; set; } = new();
        [JsonPropertyName("balance")] public double Balance => OwedBy.Values.Sum() - Owes.Values.Sum();

        public void LendTo(User borrower, double amount)
        {
            if (Owes.TryGetValue(borrower.Name, out var owed))
            {
                var net = amount - owed;
                switch (net)
                {
                    case < 0:
                        Owes[borrower.Name] = -net;
                        borrower.OwedBy[Name] = -net;
                        break;
                    case > 0:
                        Owes.Remove(borrower.Name);
                        OwedBy.Add(borrower.Name, net);
                        borrower.OwedBy.Remove(Name);
                        borrower.Owes.Add(Name, net);
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
    
    public class GetUsersRequest { [JsonPropertyName("users")] public List<string> Users { get; init; } = []; }
    public class AddUserRequest { [JsonPropertyName("user")] public string Name { get; init; } = ""; }
    
    private readonly SortedDictionary<string, User> _users = new((JsonSerializer.Deserialize<List<User>>(database) ?? []).ToDictionary(u => u.Name));
    public string Get(string url, string? payload = null)
    {
        switch (url)
        {
            case "/users":
                if (payload == null) return JsonSerializer.Serialize(_users.Values);
                GetUsersRequest usersRequest = JsonSerializer.Deserialize<GetUsersRequest>(payload) ?? throw new ArgumentException();
                return JsonSerializer.Serialize(usersRequest.Users.Select(name => _users[name]).OrderBy(user => user.Name));
            default:
                throw new ArgumentException();
        }
    }

    public string Post(string url, string payload)
    {
        switch (url)
        {
            case "/add":
                var addRequest = JsonSerializer.Deserialize<AddUserRequest>(payload) ?? throw new ArgumentException();
                return _users.TryAdd(addRequest.Name, new User { Name = addRequest.Name }) ? JsonSerializer.Serialize(_users[addRequest.Name]) : throw new ArgumentException();
            case "/iou":
                var iouRequest = JsonSerializer.Deserialize<IouRequest>(payload) ?? throw new ArgumentException();
                var (lender, borrower, amount) = (_users[iouRequest.Lender], _users[iouRequest.Borrower], iouRequest.Amount);
                lender.LendTo(borrower, amount);
                return JsonSerializer.Serialize(new[] { lender.Name, borrower.Name }.Order().Select(name => _users[name]));
            default:
                throw new ArgumentException();
        }
    }
}
