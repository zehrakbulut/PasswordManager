using FluentValidation;
using PasswordManager.Application.Dtos.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.AuthFeature.Validators
{
	public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
	{
		public RegisterRequestValidator()
		{
			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email cannot be empty.")
				.EmailAddress().WithMessage("Please enter a valid email address.")
				.MaximumLength(100).WithMessage("Email must be at most 100 characters.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password cannot be empty.")
				.MinimumLength(8).WithMessage("Password must be at least 8 characters.")
				.MaximumLength(40).WithMessage("Password must be at most 40 characters.")
				.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
				.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
				.Matches("[0-9]").WithMessage("Password must contain at least one digit.")
				.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username cannot be empty.")
				.MinimumLength(3).WithMessage("Username must be at least 3 characters.")
				.MaximumLength(30).WithMessage("Username must be at most 30 characters.")
				.Matches("^[a-zA-Z0-9]+$").WithMessage("Username must contain only letters and numbers.");
		}
	}
}
