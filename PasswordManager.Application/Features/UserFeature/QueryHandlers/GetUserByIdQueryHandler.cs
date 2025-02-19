using MediatR;
using PasswordManager.Application.Features.UserFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.UserFeature.QueryHandlers
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public GetUserByIdQueryHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			return user;
		}
	}
}
