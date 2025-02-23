using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Middlewares.Validation
{
	public class ValidationResponse
	{
		public List<ValidationFailure> Details { get; set; }
	}
}
