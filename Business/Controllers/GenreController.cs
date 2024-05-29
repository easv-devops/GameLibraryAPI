using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GameLibraryAPI.Data;

namespace GameLibraryAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private DatabaseActions db;

    [HttpGet]
    [Route("GetGenres")]
    public void getGenres()
    {
        using (SqlConnection sqlConnection = new SqlConnection(db.getDBString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Genre";
                cmd.Connection = sqlConnection;
        
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            } 
        }
    }
    
}