using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Responses.User
{
	public class GetAllUsersResponseDto
	{
		public List<GetUserByIdResponseDto> Users { get; set; }
	}
}
