using System.Numerics;

public static class IntergalacticTransmission
{
    public static byte[] GetTransmitSequence(byte[] message) =>
        message
            .SelectMany(ToBits)
            .Chunk(7)
            .Select(chunk => chunk
                .Concat(new bool[7 - chunk.Length])
                .Append(chunk.Count(bit => bit) % 2 != 0))
            .Select(ToByte)
            .ToArray();

    public static byte[] DecodeSequence(byte[] receivedSeq) =>
        receivedSeq
            .SelectMany(b => ReadAsBits(b).Take(7))
            .Chunk(8)
            .Where(chunk => chunk.Length == 8)
            .Select(ToByte)
            .ToArray();

    private static IEnumerable<bool> ReadAsBits(byte transmission) =>
        BitOperations.PopCount(transmission) % 2 == 0
            ? ToBits(transmission)
            : throw new ArgumentException();

    private static IEnumerable<bool> ToBits(byte value) =>
        Enumerable.Range(0, 8).Select(offset => (value & (1 << (7 - offset))) != 0);

    private static byte ToByte(IEnumerable<bool> bits) =>
        bits.Aggregate<bool, byte>(0, (current, bit) => (byte)((current << 1) | (bit ? 1 : 0)));
}
