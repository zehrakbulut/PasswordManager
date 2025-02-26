﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Dtos.Requests.Password
{
	public class UpdatePasswordRequestDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }   
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
