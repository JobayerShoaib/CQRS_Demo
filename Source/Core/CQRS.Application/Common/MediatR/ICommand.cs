using CQRS.Application.Common.Models;
using MediatR;

namespace CQRS.Application.Common.MediatR;

public interface ICommand:IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
