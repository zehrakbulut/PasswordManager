using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Requests.Auth
{
	public class RegisterRequestDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
	}
}
