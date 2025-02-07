using MediatR;
using PasswordManager.Application.Features.PasswordFeature.Queries;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.QueriesHandlers
{
	public class GetAllPasswordQueryHandler : IRequestHandler<GetAllPasswordQuery, List<Password>>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;

		public GetAllPasswordQueryHandler(IRepositoryBase<Password> passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public async Task<List<Password>> Handle(GetAllPasswordQuery request, CancellationToken cancellationToken)
		{
			var passwords = await _passwordRepository.GetAllAsync();
			return passwords.ToList();	
		}
	}
}
