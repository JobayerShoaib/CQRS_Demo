using CQRS.Application.Repositories.Common;
using CQRS.Domain.Entities.Setup;

namespace CQRS.Application.Repositories.Setups.Countries;

public interface ICountryCommandRepository : IGenericCommandRepository<Country>
{
}
