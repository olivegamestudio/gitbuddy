using System.Security.Cryptography;
using System.Text;

namespace GitBuddy;

public static class Sha256Hash
{
    public static byte[] ComputeSHA256Hash(string input)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        return sha256.ComputeHash(bytes);
    }

    public static bool CompareHashes(byte[] hash1, byte[] hash2)
    {
        if (hash1.Length != hash2.Length)
        {
            return false;
        }

        for (int i = 0; i < hash1.Length; i++)
        {
            if (hash1[i] != hash2[i])
            {
                return false;
            }
        }

        return true;
    }
}
