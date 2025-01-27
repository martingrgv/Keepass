namespace Keepass.Application.Contracts.CQRS
{
    public interface ICommand : IRequest<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    { 
    }
}
