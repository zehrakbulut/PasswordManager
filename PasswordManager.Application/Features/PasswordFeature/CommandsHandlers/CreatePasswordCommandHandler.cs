using MediatR;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.CommandsHandlers
{
	public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, int>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;
		private readonly IRepositoryBase<User> _userRepository;

		public CreatePasswordCommandHandler(IRepositoryBase<Password> passwordRepository, IRepositoryBase<User> userRepository)
		{
			_passwordRepository = passwordRepository;
			_userRepository = userRepository;
		}

		public async Task<int> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.UserId);
			if (user == null)
			{
				throw new InvalidOperationException($"User with ID {request.UserId} not found.");
			}


			var newPassword = new Password
			{
				Name = request.Name,
				Username = request.Username,
				HashedPassword = request.HashedPassword,
				UserId = request.UserId
			};

			await _passwordRepository.AddAsync(newPassword);
			await _passwordRepository.SaveChangesAsync(); 
			return newPassword.Id;

		}
	}
}
