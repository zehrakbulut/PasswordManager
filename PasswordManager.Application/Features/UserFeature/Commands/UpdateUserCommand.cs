using MediatR;

namespace PasswordManager.Application.Features.UserFeature.Commands
{
	public class UpdateUserCommand:IRequest<bool>
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string HashedMasterPassword { get; set; }
	}
}
