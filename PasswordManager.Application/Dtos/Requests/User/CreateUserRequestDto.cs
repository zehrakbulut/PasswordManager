using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Requests.User
{
	public class CreateUserRequestDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; } // Burada şifre hashlenmeden gelir
	}
}
