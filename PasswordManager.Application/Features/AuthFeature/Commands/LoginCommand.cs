using MediatR;
using PasswordManager.Application.Dtos.Responses.Auth;

namespace PasswordManager.Application.Features.AuthFeature.Commands
{
	public class LoginCommand : IRequest<AuthorizeResponseDto>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
