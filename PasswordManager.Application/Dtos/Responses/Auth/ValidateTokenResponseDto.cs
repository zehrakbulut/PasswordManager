

namespace PasswordManager.Application.Dtos.Responses.Auth
{
	public class ValidateTokenResponseDto
	{
		public string AccessToken { get; set; }

		public bool IsValid { get; set; }
	}
}
