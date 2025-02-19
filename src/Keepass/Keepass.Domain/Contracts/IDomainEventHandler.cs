using MediatR;

namespace Keepass.Domain.Contracts
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
