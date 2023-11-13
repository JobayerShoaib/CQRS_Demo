using CQRS.Application.Features.Setups.Countries.Queries.QRM;

namespace CQRS.Application.Services.Setups.Countries;

public interface ICountryQueryService
{
    Task<CountryByIdRM> GetById(int id, CancellationToken cancellationToken = default);
}
