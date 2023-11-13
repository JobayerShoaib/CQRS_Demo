using CQRS.Domain.Entities.Setup;

namespace CQRS.Application.Services.Setups.Countries;

public interface ICountryQueryService
{
    Task<Country> GetById(int id, CancellationToken cancellationToken = default);
}
