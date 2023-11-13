using Microsoft.Data.SqlClient;

namespace CQRS.Application.Common.Helpers;

public interface IConnectionFactory
{
    SqlConnection CreateConnection();
}
