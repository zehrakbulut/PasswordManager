using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Responses.Auth
{
	public record UpdateUserResponseDto
	{
		public bool Result { get; set; }
	}
}
