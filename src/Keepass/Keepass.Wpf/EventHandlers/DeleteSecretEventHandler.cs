using Keepass.Domain.Contracts;
using Keepass.Domain.Events;

namespace Keepass.Wpf.Events
{
    public class DeleteSecretEventHandler(SecretCollectionViewModel viewModel) : IDomainEventHandler<DeleteSecretEvent>
    {
        public Task Handle(DeleteSecretEvent notification, CancellationToken cancellationToken)
        {
            var secretViewModel = notification.Secret.Adapt<SecretViewModel>();
            viewModel.Secrets.Remove(secretViewModel);

            return Task.CompletedTask;
        }
    }
}
