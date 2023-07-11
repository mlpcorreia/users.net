using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace UserProfile.Pages;

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
                int tmpId;
                if (int.TryParse(id, out tmpId))
                {
                    command.CommandText = "SELECT username, profile FROM users WHERE user_id = $id";
                    command.Parameters.AddWithValue("$id", tmpId);
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
    }

    public void OnPost(UserParam tmp)
    {
        using (var connection = new SqliteConnection("Data Source=users.db"))
        {
            
            Console.WriteLine("Username: " + tmp.uname + " Profile: " + tmp.profile +  " Role: " + tmp.role);
            //orm.Insert<Person>(person);
            //return;
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
