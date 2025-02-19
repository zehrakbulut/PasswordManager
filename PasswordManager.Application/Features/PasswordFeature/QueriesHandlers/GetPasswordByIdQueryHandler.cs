using MediatR;
using PasswordManager.Application.Features.PasswordFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.PasswordFeature.QueriesHandlers
{
	public class GetPasswordByIdQueryHandler : IRequestHandler<GetPasswordByIdQuery, Password>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;

		public GetPasswordByIdQueryHandler(IRepositoryBase<Password> passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public async Task<Password> Handle(GetPasswordByIdQuery request, CancellationToken cancellationToken)
		{
			var password = await _passwordRepository.GetByIdAsync(request.Id);
			return password;
		}
	}
}
