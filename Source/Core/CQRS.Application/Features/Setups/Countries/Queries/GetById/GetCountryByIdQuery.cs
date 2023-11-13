using CQRS.Application.Common.MediatR;
using CQRS.Application.Common.Models;
using CQRS.Application.Features.Setups.Countries.Queries.QRM;
using CQRS.Application.Services.Setups.Countries;

namespace CQRS.Application.Features.Setups.Countries.Queries.GetById;

public sealed class GetCountryByIdQuery : IQuery<CountryByIdRM>
{
    public int Id { get; set; }
}

public sealed class GetCompanyByIdQueryHandler : IQueryHandler<GetCountryByIdQuery, CountryByIdRM>
{
    private readonly ICountryQueryService _countryQueryService;

    public GetCompanyByIdQueryHandler(ICountryQueryService countryQueryService)
    {
        _countryQueryService = countryQueryService;
    }
    public async Task<Result<CountryByIdRM>> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
    {
        var data = await _countryQueryService.GetById(query.Id, cancellationToken);
        return new Result<CountryByIdRM>().Success(data);
    }
}
