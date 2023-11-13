using FluentValidation;

namespace CQRS.Application.Features.Setups.Countries.Commands.Create;

public class CountryCreateCommandValidation : AbstractValidator<CountryCreateCommand>
{
    public CountryCreateCommandValidation()
    {
        RuleFor(x=>x.CountryName)
            .NotEmpty()
            .WithMessage("Country name is required");
    }
}
