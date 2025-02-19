using MediatR;

namespace PasswordManager.Application.Features.UserFeature.Commands
{
	public record CreateUserCommand:IRequest<int>
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string HashedMasterPassword { get; set; }
	}
}
