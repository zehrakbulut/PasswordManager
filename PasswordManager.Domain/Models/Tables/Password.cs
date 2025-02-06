using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models.Tables
{
	public class Password
	{
		public int Id { get; set; }
		public string Name { get; set; }   //site adi
		public string Username { get; set; }
		public string HashedPassword { get; set; }  //hashlenmis sifre
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
