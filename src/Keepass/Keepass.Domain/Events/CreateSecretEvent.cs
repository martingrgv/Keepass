using Keepass.Domain.Contracts;
using Keepass.Domain.Entities;

namespace Keepass.Domain.Events
{
    public record CreateSecretEvent(Secret Secret) : IDomainEvent;
}
