using CQRS.Application.Repositories;
using CQRS.Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CQRS.Infrastructure.Persistence;

public class CQRSDbContext : DbContext//, ICQRSDbContext
{
    public CQRSDbContext(DbContextOptions<CQRSDbContext> options) : base(options)
    {        
    }
    public virtual DbSet<Country> Country { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

    }
}
