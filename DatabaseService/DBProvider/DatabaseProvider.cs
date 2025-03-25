using System.Data.SqlClient;
using Dapper;
using DatabaseService.DBCommands;

namespace DatabaseService.DBProvider;

public class DatabaseProvider(string connectionString)
{
    private string ConnectionString { get; set; } = connectionString;

    [Obsolete("Obsolete")]
    public void CreateDatabase()
    {
        try
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var dbName = "School";
            connection.ExecuteAsync(DbCommands.CreateDbCommandWithNotExists(dbName));
        }
        catch(SqlException e)
        
        {
            throw new Exception(e.Message);
        }
    }
    
    
}