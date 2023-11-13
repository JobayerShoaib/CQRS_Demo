using CQRS.Application.Features.Setups.Countries.Queries.QRM;
using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Application.Services.Setups.Countries;

namespace CQRS.Infrastructure.ImpServices.Setups.Countries;

public class CountryQueryService : ICountryQueryService
{
    private readonly ICountryQueryRepository _countryQueryRepository;


    public CountryQueryService(ICountryQueryRepository countryQueryRepository
        )
    {
        _countryQueryRepository = countryQueryRepository;

    }

    public async Task<CountryByIdRM> GetById(int id, CancellationToken cancellationToken = default)
    {
        var data = await _countryQueryRepository.GetByIdWithDapper(id, cancellationToken);
        return data;
    }
}
