
using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Commands
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private static List<User> _users = new List<User>();
		private static int _nextUserId = 1;
		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User()
			{
				Id = _nextUserId++,
				UserName = request.UserName,
				Email = request.Email,
				HashedMasterPassword = request.HashedMasterPassword
			};

			_users.Add(user);
			return user.Id;
		}
	}
}
