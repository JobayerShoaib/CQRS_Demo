using CQRS.Application.Features.Setups.Countries.Queries.QRM;
using CQRS.Application.Repositories.Common;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Application.Repositories.Setups.Countries;

public interface ICountryQueryRepository : IGenericQueryRepository<Country>
{
    Task<CountryByIdRM> GetByIdWithDapper(int id, CancellationToken cancellationToken);
}
