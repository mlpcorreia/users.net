
using Microsoft.Data.Sqlite;

if (!File.Exists("users.db"))
{
    using (var connection = new SqliteConnection("Data Source=users.db"))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            @"CREATE TABLE IF NOT EXISTS users(user_id INTEGER PRIMARY KEY, username VARCHAR(255) NOT NULL, role VARCHAR(255), profile VARCHAR(255));
              INSERT INTO users(user_id, username, role) VALUES (1, 'admin', 'admin'), (2, 'randN', 'user')";

        command.ExecuteNonQuery();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors();
/*builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://portal.example.com");
        });
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//app.UseCors();
app.UseCors(tmp => tmp.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapRazorPages();

app.Run();