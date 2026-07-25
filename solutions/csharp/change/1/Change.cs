public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (coins.Length == 0) throw new ArgumentException();
        Dictionary<int, List<int>> coinLists = new() { [0] = [] };
        for (int i = coins[0]; i <= target; i++)
        {
            foreach (var coin in coins)
            {
                if (!coinLists.TryGetValue(i - coin, out var coinList)) continue;
                if (coinLists.TryGetValue(i, out var preList))
                {
                    if (preList.Count > coinList.Count + 1) coinLists[i] = coinList.Append(coin).ToList();
                }
                else coinLists[i] = coinList.Append(coin).ToList();
            }
        }
        return coinLists.TryGetValue(target, out var result) ? result.Order().ToArray() : throw new ArgumentException();
    }
}