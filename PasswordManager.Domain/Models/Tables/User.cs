using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models.Tables
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string HashedMasterPassword { get; set; } //hashlenmis ana sifre
		public List<Password> Password { get; set; }
	}
}
