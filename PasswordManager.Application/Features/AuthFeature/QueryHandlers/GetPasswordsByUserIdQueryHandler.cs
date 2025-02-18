using MediatR;
using PasswordManager.Application.Features.AuthFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.AuthFeature.QueryHandlers
{
	public class GetPasswordsByUserIdQueryHandler : IRequestHandler<GetPasswordsByUserIdQuery, IEnumerable<Password>>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;

		public GetPasswordsByUserIdQueryHandler(IRepositoryBase<Password> passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public async Task<IEnumerable<Password>> Handle(GetPasswordsByUserIdQuery request, CancellationToken cancellationToken)
		{
			return await _passwordRepository.GetAllAsync(p => p.UserId == request.UserId);
		}
	}
}
