using CQRS.Application.Common.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CQRS.Infrastructure.Helpers;

public sealed class ConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(
            _configuration.GetConnectionString("CQRSConnectionString"));
    }
}
