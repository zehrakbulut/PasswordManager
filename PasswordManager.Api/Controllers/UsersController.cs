using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Application.Features.UserFeature.Queries;

namespace PasswordManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUserAsync(CreateUserCommand command)
		{
			var userId = await _mediator.Send(command);
			return Ok(new { Id = userId });
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserByIdAsync(int id)
		{
			var query = new GetUserByIdQuery { Id = id };
			var user = await _mediator.Send(query);
			return Ok(user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserCommand command)
		{
			if( id != command.Id)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			if (!result)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserAsync(int id)
		{
			var query = new GetUserByIdQuery { Id = id };
			var user = await _mediator.Send(query);

			if(user == null)
			{
				return NotFound();
			}

			var command = new DeleteUserCommand { Id = id };
			var result = await _mediator.Send(command);

			if(result)
			{
				return NoContent();
			}

			return BadRequest();
		}

		[HttpGet("UserList")]
		public async Task<IActionResult> GetAllAsync()
		{
			var query = new GetAllUserQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
