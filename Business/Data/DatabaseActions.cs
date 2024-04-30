namespace GameLibraryAPI.Data;

using System.Data.SqlClient;

public class DatabaseActions
{
    private static string connectionString;

    public DatabaseActions()
    {
        connectionString = "";
    }

    public String getDBString()
    {
        return connectionString;
    }
}
