using BCrypt.Net;

namespace PasswordManager.Application.Helpers
{
	public static class PasswordHasher
	{
		// Şifreyi hashleme
		public static string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		// Girilen şifreyi hash ile karşılaştırma
		public static bool VerifyPassword(string password, string hashedPassword)
		{
			return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
		}
	}
}
