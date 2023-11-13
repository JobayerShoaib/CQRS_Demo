using CQRS.Application.Common.MediatR;
using CQRS.Application.Common.Models;
using CQRS.Application.Services.Setups.Countries;
using MediatR;

namespace CQRS.Application.Features.Setups.Countries.Commands.Create;

public class CountryCreateCommand : ICommand
{
    public string CountryName { get; set; }
    public string CountryNameBN { get; set; }
    public string CountryShortCode { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CountryCreateCommandHandler : ICommandHandler<CountryCreateCommand>
{
    private readonly ICountryCommandService _countryCommandService;

    public CountryCreateCommandHandler(ICountryCommandService countryCommandService)
    {
        _countryCommandService = countryCommandService;
    }

    public async Task<Result> Handle(CountryCreateCommand command, CancellationToken cancellationToken)
    {
        return await _countryCommandService.Create(command, false, cancellationToken);
    }


}
