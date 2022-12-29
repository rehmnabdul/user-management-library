using System.Text.Json;
using UserManagementLibrary;
using UserManagementLibrary.Models;

const string connectionString = "Data Source=localhost;Initial Catalog=UserManagementDB;Integrated Security=False;User ID=appuser;Password=12345678;TrustServerCertificate=True;MultipleActiveResultSets=True;";
await UserManagement.Init(connectionString);

var user = await UserManagement.GetUserById(3);
Console.WriteLine(JsonSerializer.Serialize(user.Message));
Console.WriteLine(JsonSerializer.Serialize(user.Data));

var newUser = new User
{
    Uid = Guid.NewGuid().ToString(),
    FirstName = "Muhammad",
    LastName = "Ali",
    Email = "mali@gmail.com"
};
user = await UserManagement.CreateUser(newUser, "new password");
Console.WriteLine(JsonSerializer.Serialize(user.Message));
Console.WriteLine(JsonSerializer.Serialize(user.Data));