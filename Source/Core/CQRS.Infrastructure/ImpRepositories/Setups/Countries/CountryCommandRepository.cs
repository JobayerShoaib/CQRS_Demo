using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Domain.Entities.Setup;
using CQRS.Infrastructure.ImpRepositories.Common;
using CQRS.Infrastructure.Persistence;

namespace CQRS.Infrastructure.ImpRepositories.Setups.Countries;

public class CountryCommandRepository : GenericCommandRepository<Country>, ICountryCommandRepository
{
    private readonly CQRSDbContext _dbCon;

    public CountryCommandRepository(CQRSDbContext dbCon) : base(dbCon)
    {
        _dbCon = dbCon;
    }
}
