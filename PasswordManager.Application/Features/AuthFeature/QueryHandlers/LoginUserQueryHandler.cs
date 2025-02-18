using MediatR;
using PasswordManager.Application.Features.AuthFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Application.Helpers;
using PasswordManager.Domain.Models.Tables;
using PasswordManager.Application.Interfaces;
using PasswordManager.Application.Dtos.Responses.Auth;

namespace PasswordManager.Application.Features.AuthFeature.QueryHandlers
{
	public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginResponseDto?>
	{
		private readonly IRepositoryBase<User> _userRepository;
		private readonly IJwtService _jwtService;

		public LoginUserQueryHandler(IRepositoryBase<User> userRepository, IJwtService jwtService)
		{
			_userRepository = userRepository;
			_jwtService = jwtService;
		}

		public async Task<LoginResponseDto?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetSingleAsync(u => u.Email == request.Email);

			if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.HashedMasterPassword))
			{
				return null; // Hatalı giriş
			}

			// Kullanıcı başarılı giriş yaptı, JWT Token oluştur
			var token = _jwtService.GenerateToken(user);
			return new LoginResponseDto { Token = token };
		}
	}
}
