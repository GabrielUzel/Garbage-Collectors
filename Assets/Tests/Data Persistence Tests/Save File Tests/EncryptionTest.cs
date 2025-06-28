using System;
using NUnit.Framework;

public class EncryptionTests
{
  [Test]
  public void VerifyTextIntegrity_Test()
  {
    string plainText = "Teste de criptografia!";
    string encrypted = Encryption.Encrypt(plainText);

    Assert.IsNotNull(encrypted);
    Assert.IsNotEmpty(encrypted);
    Assert.AreNotEqual(plainText, encrypted, "O texto criptografado não deveria ser igual ao texto original.");
  }

  [Test]
  public void DescryptionIsWorking_Test()
  {
    string plainText = "Teste de criptografia!";
    string encrypted = Encryption.Encrypt(plainText);
    string decrypted = Encryption.Decrypt(encrypted);

    Assert.AreEqual(plainText, decrypted, "O texto descriptografado não corresponde ao original.");
  }

  [Test]
  public void DecryptionCurruptedData_Test()
  {
    string plainText = "Teste de criptografia!";
    string encrypted = Encryption.Encrypt(plainText);
    string corrupted = encrypted[..(encrypted.Length / 2)];

    Assert.Throws<ArgumentException>(() =>
    {
      Encryption.Decrypt(corrupted);
    });
  }

  [Test]
  public void Encrypt_TwiceSameInput_ProducesDifferentOutputs()
  {
    string input = "Teste de criptografia!";

    string encrypted1 = Encryption.Encrypt(input);
    string encrypted2 = Encryption.Encrypt(input);

    Assert.AreNotEqual(encrypted1, encrypted2, "Criptografias com IVs aleatórios devem gerar saídas diferentes.");
  }
}
