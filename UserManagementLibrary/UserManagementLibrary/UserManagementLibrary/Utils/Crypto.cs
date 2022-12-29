using System.Security.Cryptography;
using System.Text;

namespace UserManagementLibrary.Utils;

public static class Crypto
{
    static IEnumerable<byte> GetHash(string inputString, HashAlgorithm algorithm)
    {
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    static string GetHashString(string inputString)
    {
        return GetHashString(inputString, SHA1.Create());
    }

    private static string GetHashString(string inputString, HashAlgorithm algorithm)
    {
        var sb = new StringBuilder();
        foreach (var b in GetHash(inputString, algorithm))
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordKey)
    {
        using var hmac = new HMACSHA512();
        passwordKey = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordKey)
    {
        using var hmac = new HMACSHA512(passwordKey);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}