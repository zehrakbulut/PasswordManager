using MediatR;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Features.PasswordFeature.Queries
{
	public class GetAllPasswordQuery:IRequest<List<Password>>
	{
	}
}
