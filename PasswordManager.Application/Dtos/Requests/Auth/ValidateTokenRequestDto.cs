

namespace PasswordManager.Application.Dtos.Requests.Auth
{
	public class ValidateTokenRequestDto
	{
		public string RefreshToken { get; set; }
		public string AccessToken { get; set; }
	}
}
