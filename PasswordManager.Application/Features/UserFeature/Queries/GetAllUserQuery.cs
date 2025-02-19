using MediatR;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.UserFeature.Queries
{
	public class GetAllUserQuery : IRequest<List<User>>
	{
	}
}
