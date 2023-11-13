using System.Linq.Expressions;

namespace CQRS.Application.Repositories.Common;

public interface IGenericQueryRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);
}
