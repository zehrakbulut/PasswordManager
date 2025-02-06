using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Commands
{
	public class CreateUserCommand:IRequest<int>
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string HashedMasterPassword { get; set; }
	}
}
