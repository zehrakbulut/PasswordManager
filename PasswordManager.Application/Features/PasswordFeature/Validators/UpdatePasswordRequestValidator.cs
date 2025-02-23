using FluentValidation;
using PasswordManager.Application.Dtos.Requests.Password;

namespace PasswordManager.Application.Features.PasswordFeature.Validators
{
	public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequestDto>
	{
		public UpdatePasswordRequestValidator()
		{
			RuleFor(x => x.Id)
				.GreaterThan(0).WithMessage("Id must be valid.");

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name cannot be empty.")
				.MaximumLength(100).WithMessage("Name must be at 30 characters.");

			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username cannot be empty.")
				.MinimumLength(3).WithMessage("Username must be at least 3 characters.")
				.MaximumLength(30).WithMessage("Username must be at most 30 characters.")
				.Matches("^[a-zA-Z0-9]+$").WithMessage("Username must contain only letters and numbers.");

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