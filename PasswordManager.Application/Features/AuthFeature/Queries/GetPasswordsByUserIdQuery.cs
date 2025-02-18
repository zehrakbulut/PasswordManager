using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.AuthFeature.Queries
{
	public class GetPasswordsByUserIdQuery : IRequest<IEnumerable<Password>>
	{
		public int UserId { get; set; }
	}
}
