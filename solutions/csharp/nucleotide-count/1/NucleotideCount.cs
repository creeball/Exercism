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
            count[nucleotide switch
            {
                'A' => 'A',
                'C' => 'C',
                'G' => 'G',
                'T' => 'T',
                _ => throw new ArgumentException("Unknown nucleotide")
            }]++;
        }
        return count;
    }
}