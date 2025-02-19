using MediatR;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.UserFeature.Queries
{
	public class GetUserByIdQuery:IRequest<User>
	{
		public int Id { get; set; }
	}
}
