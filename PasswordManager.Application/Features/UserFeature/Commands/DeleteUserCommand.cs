using MediatR;

namespace PasswordManager.Application.Features.UserFeature.Commands
{
	public class DeleteUserCommand:IRequest<bool>
	{
		public int Id { get; set; }
	}
}
