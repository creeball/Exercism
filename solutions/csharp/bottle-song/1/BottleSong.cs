public static class BottleSong
{
    private static readonly string[] Nums1 = ["No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];
    private static readonly string[] Nums2 =
        ["no", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"];
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> list = new();
        while (takeDown-- > 0)
        {
            list.Add($"{Nums1[startBottles]} green bottle{(startBottles != 1 ? "s" : "")} hanging on the wall,\n{Nums1[startBottles]} green bottle{(startBottles != 1 ? "s" : "")} hanging on the wall,\nAnd if one green bottle should accidentally fall,\nThere'll be {Nums2[startBottles - 1]} green bottle{(startBottles - 1 != 1 ? "s" : "")} hanging on the wall.");
            startBottles--;
        }
        return string.Join("\n\n", list).Split('\n');
    }
}