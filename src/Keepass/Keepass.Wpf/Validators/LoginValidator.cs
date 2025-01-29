using FluentValidation;

namespace Keepass.Wpf.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required");
            RuleFor(x => x.Key).Length(3, 20).WithMessage("Key must be between 3 and 20 characters long");
        }
    }
}
