using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Application
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
	}
}
