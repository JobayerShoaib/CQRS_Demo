using CQRS.Application.Common.Helpers;
using CQRS.Application.Features.Setups.Countries.Queries.QRM;
using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Domain.Entities.Setup;
using CQRS.Infrastructure.ImpRepositories.Common;
using CQRS.Infrastructure.Persistence;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CQRS.Infrastructure.ImpRepositories.Setups.Countries
{
    public class CountryQueryRepository : GenericQueryRepository<Country>, ICountryQueryRepository
    {
        private readonly CQRSDbContext _dbCon;
        private readonly IConnectionFactory _connectionFactory;

        public CountryQueryRepository(CQRSDbContext dbCon,
             IConnectionFactory connectionFactory) : base(dbCon)
        {
            _dbCon = dbCon;
            _connectionFactory = connectionFactory;
        }

        public async Task<CountryByIdRM> GetByIdWithDapper(int id, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            
            var data =await sqlConnection.QueryFirstOrDefaultAsync<CountryByIdRM>
                (@"Select CountryId,CountryName,CountryNameBN,CountryShortCode 
                    FROM Country
                    WHERE CountryId=@id",
                    new
                    {
                        id
                    });
            return data;
        }
    }
}
