using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using PasswordManager.Application.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Helpers
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _configuration;

		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GenerateToken(User user)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Kullanıcı ID'si
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email), // Kullanıcı adı veya email
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Token ID
            };

			var token = new JwtSecurityToken(
				issuer: jwtSettings["Issuer"],
				audience: jwtSettings["Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
