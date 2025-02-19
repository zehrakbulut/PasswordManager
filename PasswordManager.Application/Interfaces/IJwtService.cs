using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Interfaces
{
	public interface IJwtService
	{
		string GenerateToken(User user);
	}
}
