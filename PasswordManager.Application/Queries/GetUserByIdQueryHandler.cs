using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Queries
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
	{
		private static List<User> _users = new List<User>();
		public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = _users.FirstOrDefault(u=>u.Id == request.Id);
			return user;
		}
	}
}
