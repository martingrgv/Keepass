namespace Keepass.Application.Secrets.Commands.CreateSecret
{
    public class CreateSecretCommandValidator : AbstractValidator<CreateSecretCommand>
    {
        public CreateSecretCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
