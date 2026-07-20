public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> count = new()
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        foreach (var nucleotide in sequence)
        {
            if (count.ContainsKey(nucleotide))
            {
                count[nucleotide]++;
            }
            else throw new ArgumentException();
        }
        return count;
    }
}