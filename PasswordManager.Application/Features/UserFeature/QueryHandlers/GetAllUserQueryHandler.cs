using MediatR;
using PasswordManager.Application.Features.UserFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.UserFeature.QueryHandlers
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
	{
		private readonly IRepositoryBase<User> _userRepository;

		public GetAllUserQueryHandler(IRepositoryBase<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetAllAsync();
			return users.ToList();
		}
	}
}
