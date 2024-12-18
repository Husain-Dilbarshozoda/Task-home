using System.Data;
using Npgsql;

namespace Infratructure.DataContext;

public interface IContext
{
    IDbConnection Connection();
}

public class DapperContext : IContext
{
    private readonly string connectionString =
        "Server=localhost; Port = 5432; Database = skillswap_db; Username = postgres; Password = 501040477.tj;";

    public IDbConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
