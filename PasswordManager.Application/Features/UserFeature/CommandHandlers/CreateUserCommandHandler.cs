using MediatR;
using Microsoft.AspNetCore.Identity;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Application.Helpers;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.UserFeature.CommandHandlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public CreateUserCommandHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var newUser = new User
			{
				UserName = request.UserName,
				Email = request.Email,
				HashedMasterPassword = PasswordHasher.HashPassword(request.HashedMasterPassword)
			};

			await _userRepository.AddAsync(newUser);
			return newUser.Id;
		}
	}
}
