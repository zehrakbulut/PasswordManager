using PasswordManager.Application.Dtos.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Responses.Password
{
	public class GetAllPasswordResponseDto
	{
		public List<GetPasswordByIdResponseDto> Passwords { get; set; }
	}
}
