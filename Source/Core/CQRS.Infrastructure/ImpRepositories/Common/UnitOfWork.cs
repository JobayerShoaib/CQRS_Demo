using CQRS.Application.Repositories.Common;
using CQRS.Infrastructure.Persistence;

namespace CQRS.Infrastructure.ImpRepositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CQRSDbContext _dbCon;

    public UnitOfWork(CQRSDbContext dbCon)
    {
        _dbCon = dbCon;
    }
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _dbCon.SaveChangesAsync(cancellationToken);
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }
}
