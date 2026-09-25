using System.Numerics;
using System.Security.Cryptography;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP)
    {
        BigInteger key;
        do
        {
            byte[] bytes = new byte[primeP.GetByteCount()];
            RandomNumberGenerator.Fill(bytes);
            key = new BigInteger(bytes, isUnsigned: true);
        } while (key <= 1 || key >= primeP);
        return key;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)  => BigInteger.ModPow(publicKey, privateKey, primeP);
}