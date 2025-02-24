namespace Keepass.Domain.Events
{
    public record UpdateSecretsEvent(List<Secret> Secrets) : IDomainEvent;
}
