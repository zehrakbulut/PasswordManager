using MediatR;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.UserFeature.CommandHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public UpdateUserCommandHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			if(user == null)
			{
				return false;
			}
			user.UserName = request.UserName;
			user.Email = request.Email;
			user.HashedMasterPassword = request.HashedMasterPassword;

			await _userRepository.UpdateAsync(user);
			return true;
		}
	}
}
