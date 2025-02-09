using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Dtos.Requests.Password;
using PasswordManager.Application.Dtos.Responses.Password;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Application.Features.PasswordFeature.Queries;

namespace PasswordManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PasswordsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PasswordsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CreatePasswordAsync(CreatePasswordRequestDto requestDto)
		{
			var command = _mapper.Map<CreatePasswordCommand>(requestDto);
			var passwordId = await _mediator.Send(command);
			return Ok(new CreatePasswordResponseDto { Id = passwordId, Name= requestDto.Name, Username = requestDto.Username });
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPasswordByIdAsync(int id)
		{
			var query = new GetPasswordByIdQuery { Id = id };
			var password = await _mediator.Send(query);
			if(password == null) 
				return NotFound();
			var responseDto = _mapper.Map<GetPasswordByIdResponseDto>(password);
			return Ok(responseDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePasswordAsync(int id, UpdatePasswordRequestDto requestDto)
		{
			if(id != requestDto.Id)
			{
				return BadRequest();
			}

			var command = _mapper.Map<UpdatePasswordCommand>(requestDto);
			var result = await _mediator.Send(command);
			return result ? Ok(new UpdatePasswordResponseDto { Success = true }) : NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePasswordAsync(int id)
		{
			var command = new DeletePasswordCommand { Id = id };
			var result = await _mediator.Send(command);
			return result ? NoContent() : NotFound();
		}

		[HttpGet("PasswordList")]
		public async Task<IActionResult> GetAllAsync()
		{
			var query = new GetAllPasswordQuery();
			var passwords = await _mediator.Send(query);
			var responseDto = _mapper.Map<GetAllPasswordResponseDto>(passwords);
			return Ok(responseDto);
		}
	}
}	
