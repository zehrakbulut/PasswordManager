using MediatR;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.AuthFeature.Commands
{
	public class RegisterCommand : IRequest<User>
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
	}
}
