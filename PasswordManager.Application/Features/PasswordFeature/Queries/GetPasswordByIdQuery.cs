using MediatR;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.PasswordFeature.Queries
{
	public class GetPasswordByIdQuery:IRequest<Password>
	{
		public int Id { get; set; }
	}
}
