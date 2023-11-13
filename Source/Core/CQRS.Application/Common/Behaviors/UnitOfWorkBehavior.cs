﻿using CQRS.Application.Repositories.Common;
using MediatR;
using System.Transactions;

namespace CQRS.Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
        )
    {
        if (IsNotCommand())
        {
            return await next();
        }
        using (var transactionScope=new TransactionScope())
        {
            var response = await next();
            await _unitOfWork.CommitAsync(cancellationToken);
            transactionScope.Complete();
            return response;
        }
           
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }
}
