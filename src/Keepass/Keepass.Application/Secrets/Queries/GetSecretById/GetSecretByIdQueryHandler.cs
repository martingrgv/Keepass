
using Keepass.Application.Contracts;

namespace Keepass.Application.Secrets.Queries.GetSecretById
{
    public class GetSecretByIdQueryHandler(ISecretRepository secretRepository)
        : IQueryHandler<GetSecretByIdQuery, GetSecretByIdResult>
    {
        public async Task<GetSecretByIdResult> Handle(GetSecretByIdQuery query, CancellationToken cancellationToken)
        {
            var secret = await secretRepository.GetSecretAsync(query.Id);

            if (secret is null)
            {
                throw new NotFoundException(query.Id.ToString());
            }

            return new GetSecretByIdResult(secret);
        }
    }
}
