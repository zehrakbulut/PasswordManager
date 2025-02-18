using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Application.Helpers
{
	public static class AESHelper
	{
		private static readonly string KeyString = "SuperSecureKey1234567890!@#$%"; // Daha güvenli bir key
		private static readonly byte[] Key = Encoding.UTF8.GetBytes(KeyString.PadRight(32));

		public static string Encrypt(string plainText)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.GenerateIV(); // Rastgele IV oluştur
				aesAlg.Key = Key;
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				{
					msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length); // IV'yi ilk başa ekle

					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(plainText);
					}

					return Convert.ToBase64String(msEncrypt.ToArray()); // Şifrelenmiş veriyi base64 olarak döndür
				}
			}
		}

		public static string Decrypt(string cipherText)
		{
			byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;

				byte[] iv = new byte[16]; // İlk 16 byte IV olacak
				byte[] encryptedData = new byte[cipherTextBytes.Length - iv.Length];

				Buffer.BlockCopy(cipherTextBytes, 0, iv, 0, iv.Length);
				Buffer.BlockCopy(cipherTextBytes, iv.Length, encryptedData, 0, encryptedData.Length);

				aesAlg.IV = iv;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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
