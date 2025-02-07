using MediatR;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.UserFeature.CommandHandlers
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public DeleteUserCommandHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			if(user == null)
			{
				return false;
			}			
			await _userRepository.DeleteAsync(user);
			return true;
		}
	}
}
