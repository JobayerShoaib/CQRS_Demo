using CQRS.Application.Common.Models;
using MediatR;

namespace CQRS.Application.Common.MediatR;

public interface IQueryHandler<TQuery,TResponse> :IRequestHandler<TQuery,Result< TResponse>>
    where TQuery : IQuery<TResponse>
{
}
