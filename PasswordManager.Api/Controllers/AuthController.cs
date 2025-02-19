using MediatR;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Dtos.Requests.Auth;
using PasswordManager.Application.Features.AuthFeature.Commands;
using PasswordManager.Application.Features.AuthFeature.Queries;

namespace PasswordManager.Api.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
		{
			var user = await _mediator.Send(new RegisterCommand
			{
				Email = request.Email,
				Password = request.Password,
				UserName = request.UserName
			});

			return Ok(new { message = "Kullanıcı başarıyla kaydedildi.", userId = user.Id });
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
		{
			var response = await _mediator.Send(new LoginUserQuery
			{
				Email = request.Email,
				Password = request.Password
			});

			if (response == null)
				return Unauthorized(new { message = "Geçersiz e-posta veya şifre" });

			return Ok(new { Token = response.Token });
		}
	}
}
