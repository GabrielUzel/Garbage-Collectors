using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Encryption
{
  private static readonly string key = "mwpjgld9y46aeswp";

  public static string Encrypt(string plainText)
  {
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
    using Aes aes = Aes.Create();
    aes.Key = keyBytes;
    aes.GenerateIV();

    using MemoryStream ms = new MemoryStream();
    ms.Write(aes.IV, 0, aes.IV.Length);

    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
    using (StreamWriter sw = new StreamWriter(cs))
    {
      sw.Write(plainText);
    }

    return Convert.ToBase64String(ms.ToArray());
  }

  public static string Decrypt(string encryptedText)
  {
    byte[] fullData = Convert.FromBase64String(encryptedText);
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);

    using Aes aes = Aes.Create();
    aes.Key = keyBytes;

    byte[] iv = new byte[aes.BlockSize / 8];
    Array.Copy(fullData, 0, iv, 0, iv.Length);
    aes.IV = iv;

    using MemoryStream ms = new(fullData, iv.Length, fullData.Length - iv.Length);
    using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
    using StreamReader sr = new(cs);
    return sr.ReadToEnd();
  }
}
