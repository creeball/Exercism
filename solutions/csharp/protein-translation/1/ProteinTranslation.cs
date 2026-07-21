public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> Codons = new()
    {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan",
        ["UAA"] = "STOP",
        ["UAG"] = "STOP",
        ["UGA"] = "STOP",
    };
    public static string[] Proteins(string strand)
    {
        List<string> proteins = new();
        for (int i = 0; i + 2 < strand.Length; i += 3)
        {
            if (!Codons.TryGetValue(strand.Substring(i, 3), out string? protein)) return [];
            if (protein == "STOP") break;
            proteins.Add(protein);
        }
        return proteins.ToArray();
    }
}