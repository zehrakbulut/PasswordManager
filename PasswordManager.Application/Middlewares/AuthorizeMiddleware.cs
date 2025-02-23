using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PasswordManager.Application.Features.AuthFeature.Commands;

namespace PasswordManager.Application.Middlewares
{
	public class AuthorizeMiddleware : IMiddleware
	{
		private readonly IMediator _mediator;
		private readonly ILogger<AuthorizeMiddleware> _logger;

		public AuthorizeMiddleware(IMediator mediator, ILogger<AuthorizeMiddleware> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			string accessToken = context.Request.Headers["AccessToken"];
			string refreshToken = context.Request.Headers["RefreshToken"];

			if (!string.IsNullOrWhiteSpace(context.Request.Headers["AccessToken"]) && !string.IsNullOrWhiteSpace(context.Request.Headers["RefreshToken"]))
			{
				CreateAccessTokenCommand command = new CreateAccessTokenCommand
				{
					RefreshToken = refreshToken,
					AccessToken = accessToken
				};

				var response = await _mediator.Send(command);

				context.Request.Headers["Authorization"] = "Bearer " + response;
				_logger.LogInformation("Authorize Middleware Header Datas, " + context.Request.Headers["Authorization"]);
			}
			await next(context);
		}
	}
}
