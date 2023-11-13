using CQRS.Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Application.Repositories;

public interface ICQRSDbContext
{
    public DbSet<Country> Country { get; set; }
}
