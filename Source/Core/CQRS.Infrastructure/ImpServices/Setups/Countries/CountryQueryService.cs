using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Application.Services.Setups.Countries;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Infrastructure.ImpServices.Setups.Countries;

public class CountryQueryService : ICountryQueryService
{
    private readonly ICountryQueryRepository _countryQueryRepository;

    public CountryQueryService(ICountryQueryRepository countryQueryRepository)
    {
        _countryQueryRepository = countryQueryRepository;
    }

    public async Task<Country> GetById(int id, CancellationToken cancellationToken = default)
    {
        var data= await _countryQueryRepository.GetByIdAsync(id, cancellationToken);
        return data;
    }
}
