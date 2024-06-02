using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_programming_homwork_2.Pages
{
    public class ViewDataModel : PageModel
    {
        public List<PersonInfo> PersonInfoList { get; set; }

        public void OnGet()
        {
            PersonInfoList = new List<PersonInfo>();
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PersonDB";
            string sqlQuery = "SELECT Name, Number, Address FROM Information";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonInfo person = new PersonInfo
                    {
                        Name = reader["Name"].ToString(),
                        Mobile = reader["Number"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                    PersonInfoList.Add(person);
                }
            }
        }
    }
}
