using PasswordManager.Application.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Application.Helpers
{
	public static class AESHelper
	{
		public static string Encrypt(string plainText)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.GenerateIV(); //IV'yi rastgele oluştur
				aesAlg.Key = Encoding.UTF8.GetBytes("123456aA*".PadRight(32));
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
				{
					swEncrypt.Write(plainText);
					swEncrypt.Flush();
					csEncrypt.FlushFinalBlock();

					byte[] iv = aesAlg.IV;
					byte[] encryptedData = msEncrypt.ToArray();
					byte[] result = new byte[iv.Length + encryptedData.Length];

					Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
					Buffer.BlockCopy(encryptedData, 0, result, iv.Length, encryptedData.Length);

					return Convert.ToBase64String(result);
				}
			}
		}

		public static string Decrypt(string cipherText)
		{
			// Base64 ile kodlanmış şifrelenmiş metni byte dizisine çevir
			byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes("123456aA*".PadRight(32));
				byte[] iv = new byte[16];
				byte[] encryptedData = new byte[cipherTextBytes.Length - iv.Length];

				// Şifrelenmiş veriden IV'yi ve şifrelenmiş veriyi ayır
				Buffer.BlockCopy(cipherTextBytes, 0, iv, 0, iv.Length);
				Buffer.BlockCopy(cipherTextBytes, iv.Length, encryptedData, 0, encryptedData.Length);

				aesAlg.IV = iv;

				// Decryptor oluştur
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Şifrelenmiş veriyi çöz
				using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				using (StreamReader srDecrypt = new StreamReader(csDecrypt))
				{
					return srDecrypt.ReadToEnd();
				}
			}
		}
	}
}
