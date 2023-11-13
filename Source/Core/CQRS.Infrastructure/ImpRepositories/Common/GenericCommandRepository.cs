using CQRS.Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.ImpRepositories.Common;

public class GenericCommandRepository<TEntity> : IGenericCommandRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public GenericCommandRepository(DbContext context)
    {
        _context = context;
    }
    //Internally re-usable DbSet instance.
    protected DbSet<TEntity> DbSet
    {
        get
        {
            if (_dbSet == null)
                _dbSet = _context.Set<TEntity>();
            return _dbSet;
        }
    }
    private DbSet<TEntity> _dbSet;

    public async Task<object> InsertAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        var rtn = await DbSet.AddAsync(entity);
        if (saveChanges)
        {           
            //await _context.SaveChangesAsync(cancellationToken);           
        }
        return rtn;
    }

    public async Task UpdateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        var entry = _context.Entry(entity);
        this.DbSet.Attach(entity);
        entry.State = EntityState.Modified;
        if (saveChanges)
        {
            //await _context.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task DeleteAsync(object id, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        this.DbSet.Remove(GetById(id));
        if (saveChanges)
        {
            //await _context.SaveChangesAsync(cancellationToken);
        }
    }
    private TEntity GetById(object id, CancellationToken cancellationToken = default)
    {
        return DbSet.Find(id);
    }
}
