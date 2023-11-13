using CQRS.Application.Common.Models;
using CQRS.Application.Features.Setups.Countries.Commands.Create;
using CQRS.Application.Repositories.Common;
using CQRS.Application.Repositories.Setups.Countries;
using CQRS.Application.Services.Setups.Countries;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Infrastructure.ImpServices.Setups.Countries;

public class CountryCommandService : ICountryCommandService
{
    private readonly ICountryCommandRepository _countryCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CountryCommandService(ICountryCommandRepository countryCommandRepository
        ,IUnitOfWork unitOfWork)
    {
        _countryCommandRepository = countryCommandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Create(CountryCreateCommand country, bool saveChanges = false, CancellationToken cancellationToken = default)
    {      
        Result result = new();
        Country entity = new()
        {
            CountryName = country.CountryName,
            CountryShortCode = country.CountryShortCode,
            CountryNameBN = country.CountryNameBN,
            IsDefault = country.IsDefault,
            IsActive = country.IsActive
        };
        await _countryCommandRepository.InsertAsync(entity, saveChanges, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return result.Success();
        
    }
}
