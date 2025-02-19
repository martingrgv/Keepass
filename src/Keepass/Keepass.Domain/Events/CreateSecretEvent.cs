namespace Keepass.Domain.Events
{
    public record CreateSecretEvent(Secret Secret) : IDomainEvent;
}
