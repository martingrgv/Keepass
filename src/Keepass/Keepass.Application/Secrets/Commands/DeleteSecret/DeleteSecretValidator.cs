using FluentValidation;

namespace Keepass.Application.Secrets.Commands.DeleteSecret
{
    public class DeleteSecretValidator : AbstractValidator<DeleteSecretCommand>
    {
        public DeleteSecretValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
