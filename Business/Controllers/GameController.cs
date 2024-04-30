using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GameLibraryAPI.Data;

namespace GameLibraryAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private DatabaseActions db;
    
    [HttpPost(Name = "AddGame")]
    public void AddGame(Guid gameId, String gameTitle, Guid consoleId, Guid genreId)
    {
            using (SqlConnection sqlConnection = new SqlConnection(db.getDBString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Game VALUES (@GameId, @GameTitle, @ConsoleId, @GenreId)";
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@GameTitle", gameTitle);
                    cmd.Parameters.AddWithValue("@ConsoleId", consoleId);
                    cmd.Parameters.AddWithValue("@GenreId", genreId);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
        }
    }
}