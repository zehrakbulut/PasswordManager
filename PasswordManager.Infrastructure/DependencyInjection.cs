using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Helpers;
using PasswordManager.Application.Interfaces;

namespace PasswordManager.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IJwtService, JwtService>();
			return services;
		}
	}
}
