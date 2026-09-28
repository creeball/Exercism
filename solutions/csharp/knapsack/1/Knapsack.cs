public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items) =>
        Maximum(maximumWeight, items.OrderBy(item => item.weight).ToArray());

    private static int Maximum(int maximumWeight, (int weight, int value)[] items) =>
        items
            .TakeWhile(item => item.weight <= maximumWeight)
            .Select((item, i) => item.value + Maximum(maximumWeight - item.weight, items[(i + 1)..]))
            .DefaultIfEmpty(0)
            .Max();
}
