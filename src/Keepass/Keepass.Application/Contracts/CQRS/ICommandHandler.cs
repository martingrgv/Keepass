﻿namespace Keepass.Application.Contracts.CQRS
{
    internal interface ICommandHandler<in TCommand>
        : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }

    internal interface ICommandHandler<in TCommand, TResponse> 
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
