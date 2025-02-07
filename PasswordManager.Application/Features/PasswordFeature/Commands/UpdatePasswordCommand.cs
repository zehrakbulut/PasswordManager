using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.Commands
{
	public class UpdatePasswordCommand:IRequest<bool>
	{
		public int Id { get; set; }
		public string Name { get; set; }   //site adi
		public string Username { get; set; }
		public string HashedPassword { get; set; }  //hashlenmis sifre
		public int UserId { get; set; }
	}
}
