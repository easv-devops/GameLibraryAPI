using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GameLibraryAPI.Data;

namespace GameLibraryAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class ConsoleController : ControllerBase
{
    private DatabaseActions db;
    

    [HttpGet]
    [Route("GetConsoles")]
    public void getConsoles()
    {
        using (SqlConnection sqlConnection = new SqlConnection(db.getDBString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Console";
                cmd.Connection = sqlConnection;
        
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            } 
        }
    }
    
}