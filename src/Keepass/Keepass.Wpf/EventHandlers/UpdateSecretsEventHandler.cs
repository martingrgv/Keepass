using Keepass.Application.Contracts;
using Keepass.Domain.Contracts;
using Keepass.Domain.Events;

namespace Keepass.Wpf.EventHandlers
{
    public class UpdateSecretsEventHandler(SecretCollectionViewModel viewModel, ICryptography cryptography)
        : IDomainEventHandler<UpdateSecretsEvent>
    {
        public Task Handle(UpdateSecretsEvent notification, CancellationToken cancellationToken)
        {
            var secretsViewModel = notification.Secrets.Adapt<List<SecretViewModel>>();

            foreach (var secretViewModel in secretsViewModel)
            {
                var decryptedPassword = cryptography.Decrypt(secretViewModel.Password);
                secretViewModel.Password = decryptedPassword;

                viewModel.Secrets.Add(secretViewModel);
            }

            return Task.CompletedTask;
        }
    }
}
