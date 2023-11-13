using CQRS.Application.Repositories.Common;
using CQRS.Infrastructure.ImpRepositories.Common;
using CQRS.Infrastructure.ImpRepositories.Setups.Countries;
using CQRS.Infrastructure.ImpServices.Setups.Countries;
using CQRS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace CQRS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddDbContext<CQRSDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CQRSConnectionString"), b => b.MigrationsAssembly(typeof(CQRSDbContext).Assembly.FullName)));


        services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericCommandRepository<>));
        services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
        

        Dependency(services, configuration);
        return services;
    }
    public static void Dependency(this IServiceCollection services, IConfiguration configuration)
    {


        #region Assembly Repository
        var assembliesToScan = new[]
               {
                        Assembly.GetExecutingAssembly(),
                               Assembly.GetAssembly(typeof(CountryCommandRepository)),
                        Assembly.GetAssembly(typeof(CountryCommandService)),

                   };

        //This registers the service layer: I only register the classes who name ends with "Service"(at the moment)

        services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
            .Where(s => s.Name.EndsWith("Repository")
                     || s.Name.EndsWith("Service"))
            .AsPublicImplementedInterfaces();

        #endregion Assembly Repository

    }
}
