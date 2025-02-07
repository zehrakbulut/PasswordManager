using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Application.Features.PasswordFeature.Queries;

namespace PasswordManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PasswordsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PasswordsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreatePasswordAsync(CreatePasswordCommand command)
		{
			var passwordId = await _mediator.Send(command);
			return Ok(new { Id = passwordId });
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPasswordByIdAsync(int id)
		{
			var query = new GetPasswordByIdQuery { Id = id };
			var password = await _mediator.Send(query);
			return Ok(password);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePasswordAsync(int id, UpdatePasswordCommand command)
		{
			if(id != command.Id)
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
		public async Task<IActionResult> DeletePasswordAsync(int id)
		{
			var query = new GetPasswordByIdQuery { Id = id };
			var password = await _mediator.Send(query);

			if (User == null)
			{
				return NotFound();
			}

			var command = new DeletePasswordCommand() { Id = id };
			var result = await _mediator.Send(command);

			if (result)
			{
				return NoContent();
			}
			return BadRequest();
		}

		[HttpGet("PasswordList")]
		public async Task<IActionResult> GetAllAsync()
		{
			var query = new GetAllPasswordQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}	
