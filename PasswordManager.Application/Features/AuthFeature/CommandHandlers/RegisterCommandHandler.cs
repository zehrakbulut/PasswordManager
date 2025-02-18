using MediatR;
using PasswordManager.Application.Features.AuthFeature.Commands;
using PasswordManager.Application.Helpers;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
namespace PasswordManager.Application.Features.AuthFeature.CommandHandlers
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public RegisterCommandHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			var user = new User
			{
				Email = request.Email,
				HashedMasterPassword = PasswordHasher.HashPassword(request.Password),
				UserName = request.UserName
			};

			await _userRepository.AddAsync(user);
			return user;
		}
	}
}
