using EB.Application.Services.Externals;
using System.Security.Cryptography;
using System.Text;

namespace EB.Infrastructure.EncryptionManagers;


public class EncryptionService : IEncryptionService
{

    private readonly string encryptionKey = "MyEncryptionKeyvB7uZy9kL2T!gQ$wXs4mNpR@jF5xE&hC";

    public string Encrypt(string plainText)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = GenerateKey(encryptionKey);
        aesAlg.GenerateIV();

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msEncrypt = new();
        msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

        using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using StreamWriter swEncrypt = new(csEncrypt);
            swEncrypt.Write(plainText);
        }

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = GenerateKey(encryptionKey);

        byte[] iv = new byte[aesAlg.BlockSize / 8];
        byte[] cipher = new byte[fullCipher.Length - iv.Length];

        Array.Copy(fullCipher, iv, iv.Length);
        Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

        aesAlg.IV = iv;

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new(cipher);
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);
        return srDecrypt.ReadToEnd();
    }

    private static byte[] GenerateKey(string key)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(key));
    }
}


