using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models.Requests
{
	public class UserUpdateRequestModel
	{
		public string Email { get; set; }
		public string UserName { get; set; }
	}
}
