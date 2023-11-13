using CQRS.Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CQRS.Infrastructure.ImpRepositories.Common;

public class GenericQueryRepository<TEntity> : IGenericQueryRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public GenericQueryRepository(DbContext context)
    {
        _context = context;
    }

    private DbSet<TEntity> _dbSet;
    protected DbSet<TEntity> DbSet
    {
        get
        {
            if (_dbSet == null)
                _dbSet = _context.Set<TEntity>();
            return _dbSet;
        }
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(match).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(match, cancellationToken);
    }
}
