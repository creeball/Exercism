using System.Numerics;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers) => numbers.SelectMany(ToSequence).ToArray();

    public static uint[] Decode(uint[] bytes)
    {
        var sequence = 0;
        return bytes
            .Select(b => (Byte: b, Sequence: (b & 0x80) == 0 ? sequence++ : sequence))
            .GroupBy(x => x.Sequence, x => x.Byte)
            .Select(x => ToNumber(x.ToArray()))
            .ToArray();
    }

    private static IEnumerable<uint> ToSequence(uint value) =>
        Enumerable.Range(0, ChunkCount(value))
            .Select(index => (value >> (7 * index)) & 0x7F)
            .Select((chunk, index) => index == 0 ? chunk : chunk | 0x80)
            .Reverse();

    private static int ChunkCount(uint value) =>
        value == 0 ? 1 : (31 - BitOperations.LeadingZeroCount(value)) / 7 + 1;

    private static uint ToNumber(uint[] sequence) =>
        sequence.Last() < 0x80
            ? sequence.Aggregate(0u, (value, b) => (value << 7) | (b & 0x7F))
            : throw new InvalidOperationException();
}
