using Keepass.Application.Contracts;
using Keepass.Domain.Contracts;
using Keepass.Domain.Events;

namespace Keepass.Wpf.Events
{
    public class CreateSecretEventHandler(SecretCollectionViewModel viewModel, ICryptography cryptography) : IDomainEventHandler<CreateSecretEvent>
    {
        public Task Handle(CreateSecretEvent notification, CancellationToken cancellationToken)
        {
            var secretViewModel = notification.Secret.Adapt<SecretViewModel>();

            var decryptedPassword = cryptography.Decrypt(secretViewModel.Password);
            secretViewModel.Password = decryptedPassword;

            viewModel.Secrets.Add(secretViewModel);

            return Task.CompletedTask;
        }
    }
}
