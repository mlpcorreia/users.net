using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace UserProfile.Pages;

[EnableCors]
public class User : PageModel
{

    public string username { get; set; }
    
    public string profile { get; set; }

    public void OnGet()
    {
        if (!String.IsNullOrEmpty(Request.Query["id"]))
        {
            string id = Request.Query["id"];
            using (var connection = new SqliteConnection("Data Source=users.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                // Validar o id como inteiro
                //int tmp = Int32.Parse(id);

                command.CommandText = "SELECT username, profile FROM users WHERE user_id = $id";
                command.Parameters.AddWithValue("$id", id);
                //command.CommandText = "SELECT username, profile FROM users WHERE user_id = " + id;
                //command.CommandText = $"SELECT username, profile FROM users WHERE user_id = {id}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        username = reader.GetString(0);
                        profile = reader.GetString(1);
                    }
                }
            }
        }
    }

    public void OnPost(FormParam tmp)
    {
        using (var connection = new SqliteConnection("Data Source=users.db"))
        {
            connection.Open();

            var command = connection.CreateCommand();
            //command.CommandText = String.Format("INSERT INTO users(username, role, profile) VALUES ('{0}', 'user', '{1}')", tmp.uname, tmp.profile);
            command.CommandText = "INSERT INTO users(username, role, profile) VALUES ('$username', 'user', '$profile')";
            command.Parameters.AddWithValue("$username", tmp.uname);
            command.Parameters.AddWithValue("$profile", tmp.profile);
            command.ExecuteNonQuery();
        }
    }
   
}
