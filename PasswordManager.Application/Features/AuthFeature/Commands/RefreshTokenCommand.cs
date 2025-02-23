using MediatR;
using PasswordManager.Application.Dtos.Responses.Auth;

namespace PasswordManager.Application.Features.AuthFeature.Commands
{
	public class RefreshTokenCommand : IRequest<AuthorizeResponseDto>
	{
		public string Email { get; set; }
		public string RefreshToken { get; set; }
	}
}
