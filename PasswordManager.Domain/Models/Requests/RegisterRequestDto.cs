﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models.Requests
{
	public class RegisterRequestDto
	{
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string RefreshToken { get; set; } = null;
	}
}
