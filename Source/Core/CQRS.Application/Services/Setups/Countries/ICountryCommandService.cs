using CQRS.Application.Common.Models;
using CQRS.Application.Features.Setups.Countries.Commands.Create;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Application.Services.Setups.Countries;

public interface ICountryCommandService
{
    Task<Result>Create(CountryCreateCommand country, bool saveChanges = false, CancellationToken cancellationToken = default);
}
