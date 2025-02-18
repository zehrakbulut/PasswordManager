using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Dtos.Requests.User;
using PasswordManager.Application.Dtos.Responses.User;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Application.Features.UserFeature.Queries;

namespace PasswordManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UsersController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateUserAsync(CreateUserRequestDto requestDto)
		{
			var command = _mapper.Map<CreateUserCommand>(requestDto);
			var userId = await _mediator.Send(command);
			return Ok(new CreateUserResponseDto { Id = userId, UserName= requestDto.UserName, Email=requestDto.Email});
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserByIdAsync(int id)
		{
			var query = new GetUserByIdQuery { Id = id };
			var user = await _mediator.Send(query);
			if(user == null) 
				return NotFound();
			var responseDto = _mapper.Map<GetUserByIdResponseDto>(user);
			return Ok(responseDto);
		}

		[Authorize]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserRequestDto requestDto)
		{
			if( id != requestDto.Id)
			{
				return BadRequest();
			}

			var command = _mapper.Map<UpdateUserCommand>(requestDto);
			var result = await _mediator.Send(command);
			return result ? Ok(new UpdateUserResponseDto { Success = true }) : NotFound();    
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserAsync(int id)
		{
			var command = new DeleteUserCommand { Id = id };
			var result = await _mediator.Send(command);
			return result ? NoContent() : NotFound();    
		}

		[HttpGet("UserList")]
		public async Task<IActionResult> GetAllAsync()
		{
			var query = new GetAllUserQuery();
			var users = await _mediator.Send(query);
			var responseDto = _mapper.Map<GetAllUsersResponseDto>(users);
			return Ok(responseDto);
		}
	}
}
