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
	public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
	{
		private readonly IRepositoryBase<Password> _passwordRepository;

		public UpdatePasswordCommandHandler(IRepositoryBase<Password> passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
		{
			var password = await _passwordRepository.GetByIdAsync(request.Id);
			if (password == null)
			{
				return false;	
			}

			password.Name = request.Name;
			password.Username = request.Username;
			password.HashedPassword = request.HashedPassword;
			password.UserId = request.UserId;

			await _passwordRepository.UpdateAsync(password);
			return true;
		}
	}
}
