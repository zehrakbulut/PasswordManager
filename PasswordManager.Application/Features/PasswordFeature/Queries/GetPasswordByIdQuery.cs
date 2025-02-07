using MediatR;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.PasswordFeature.Queries
{
	public class GetPasswordByIdQuery:IRequest<Password>
	{
		public int Id { get; set; }
	}
}
