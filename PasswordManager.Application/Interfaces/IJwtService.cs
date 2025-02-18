using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Interfaces
{
	public interface IJwtService
	{
		string GenerateToken(User user);
	}
}
