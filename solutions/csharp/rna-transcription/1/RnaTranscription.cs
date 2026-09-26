public static class RnaTranscription
{
    public static string ToRna(string strand) =>
        string.Concat(strand.Select(c => c switch
        {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            _ => 'U'
        }));
}