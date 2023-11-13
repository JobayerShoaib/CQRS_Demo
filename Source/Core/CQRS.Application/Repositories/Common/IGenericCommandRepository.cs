namespace CQRS.Application.Repositories.Common;

public interface IGenericCommandRepository<TEntity> where TEntity : class
{
    Task<object> InsertAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default); 
    Task DeleteAsync(object id, bool saveChanges = false, CancellationToken cancellationToken = default);    
}
