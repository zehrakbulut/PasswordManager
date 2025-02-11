using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Requests.Password
{
	public class CreatePasswordRequestDto
	{
		public int UserId { get; set; }
		public string Name { get; set; }   
		public string Username { get; set; }
		public string Password { get; set; } //girilen şifre backend tarafında aes ile hashlenicek
	}
}
