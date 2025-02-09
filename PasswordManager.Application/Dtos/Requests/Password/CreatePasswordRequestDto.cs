using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Requests.Password
{
	public class CreatePasswordRequestDto
	{
		public string Name { get; set; }   //site adi
		public string Username { get; set; }
		public string HashedPassword { get; set; }
	}
}
