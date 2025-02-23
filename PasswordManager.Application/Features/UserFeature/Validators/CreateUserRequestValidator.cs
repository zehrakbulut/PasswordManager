using FluentValidation;
using PasswordManager.Application.Dtos.Requests.User;

namespace PasswordManager.Application.Features.UserFeature.Validators
{
	public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestDto>
	{
		public CreateUserRequestValidator()
		{
			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username cannot be empty.")
				.MinimumLength(3).WithMessage("Username must be at least 3 characters.")
				.MaximumLength(30).WithMessage("Username must be at most 30 characters.")
				.Matches("^[a-zA-Z0-9]+$").WithMessage("Username must contain only letters and numbers.");

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
		}
	}
}