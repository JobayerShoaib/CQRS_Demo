using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Domain.Entities.Setup;
using CQRS.Infrastructure.ImpRepositories.Common;
using CQRS.Infrastructure.Persistence;

namespace CQRS.Infrastructure.ImpRepositories.Setups.Countries
{
    public class CountryQueryRepository : GenericQueryRepository<Country>, ICountryQueryRepository
    {
        private readonly CQRSDbContext _dbCon;

        public CountryQueryRepository(CQRSDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
