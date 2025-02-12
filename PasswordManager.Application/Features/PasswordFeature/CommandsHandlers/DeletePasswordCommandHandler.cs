using MediatR;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.CommandsHandlers
{
	public class DeletePasswordCommandHandler : IRequestHandler<DeletePasswordCommand, bool>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;

		public DeletePasswordCommandHandler(IRepositoryBase<Password> passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public async Task<bool> Handle(DeletePasswordCommand request, CancellationToken cancellationToken)
		{
			var password = await _passwordRepository.GetByIdAsync(request.Id);
			if (password == null)
			{
				return false;
			}

			await _passwordRepository.DeleteAsync(password);
			return true;
		}
	}
}
