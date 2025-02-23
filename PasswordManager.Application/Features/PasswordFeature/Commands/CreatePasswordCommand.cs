using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.Commands
{
	public class CreatePasswordCommand:IRequest<int>
	{
		public string Name { get; set; }   
		public string Username { get; set; }
		public string HashedPassword { get; set; }  
		public int UserId { get; set; }
	}
}
