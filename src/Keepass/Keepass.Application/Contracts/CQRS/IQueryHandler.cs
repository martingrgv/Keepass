namespace Keepass.Application.Contracts.CQRS
{
    internal interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {
    }
}
