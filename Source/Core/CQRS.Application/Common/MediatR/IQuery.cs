using CQRS.Application.Common.Models;
using MediatR;

namespace CQRS.Application.Common.MediatR;

public interface IQuery<TResponse>:IRequest<Result<TResponse>>
{
}
