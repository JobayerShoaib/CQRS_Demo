﻿using CQRS.Application.Common.Models;
using MediatR;

namespace CQRS.Application.Common.MediatR;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand,TResponse>:IRequestHandler<TCommand,Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
