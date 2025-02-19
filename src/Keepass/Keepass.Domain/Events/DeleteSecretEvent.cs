namespace Keepass.Domain.Events
{
    public record DeleteSecretEvent(Secret Secret) : IDomainEvent;
}
