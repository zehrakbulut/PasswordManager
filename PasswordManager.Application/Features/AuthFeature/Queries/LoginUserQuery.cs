using MediatR;
using PasswordManager.Application.Dtos.Responses.Auth;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.AuthFeature.Queries
{
	public class LoginUserQuery : IRequest<LoginResponseDto?>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
