using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Database_programming_homwork_2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            string Name = Request.Form["Name"];
            string Mobile = Request.Form["Mobile"];
            string Address = Request.Form["Address"];

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PersonDB";
            string sqlQuery = "INSERT INTO Information (Name, Number, Address) VALUES (" + "'" + Name + "', " + "'" + Mobile + "', " + "'" + Address + "')";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.ExecuteNonQuery();
            con.Close();
        }
    }
}
