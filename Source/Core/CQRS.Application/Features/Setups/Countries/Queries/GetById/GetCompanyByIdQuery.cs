using CQRS.Application.Common.MediatR;
using CQRS.Application.Common.Models;
using CQRS.Application.Services.Setups.Countries;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Application.Features.Setups.Countries.Queries.GetById;

public sealed class GetCompanyByIdQuery : IQuery<Country>
{
    public int Id { get; set; }
}

public sealed class GetCompanyByIdQueryHandler : IQueryHandler<GetCompanyByIdQuery, Country>
{
    private readonly ICountryQueryService _countryQueryService;

    public GetCompanyByIdQueryHandler(ICountryQueryService countryQueryService)
    {
        _countryQueryService = countryQueryService;
    }
    public async Task<Result<Country>> Handle(GetCompanyByIdQuery query, CancellationToken cancellationToken)
    {        
        var data= await _countryQueryService.GetById(query.Id, cancellationToken);
        return new Result<Country>().Success(data);
    }
}
