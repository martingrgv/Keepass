using FluentValidation;

namespace Keepass.Wpf.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required");
            RuleFor(x => x.Key).MinimumLength(3).WithMessage("Key must be at least 3 characters long");
        }
    }
}
