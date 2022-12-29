using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserManagementWebDemo.Models;

class DbUserManagementDesign : IDesignTimeDbContextFactory<DbUserManagement>
{
    public DbUserManagement CreateDbContext(string[] args)
    {
        const string connectionString = "Data Source=localhost;Initial Catalog=UserManagementDB;Integrated Security=False;User ID=appuser;Password=12345678;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        return new DbUserManagement(GetDbOptions(connectionString));
    }

    public static string GetSchema()
    {
        return "UserManagement";
    }

    public static DbContextOptions<DbUserManagement> GetDbOptions(string connString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbUserManagement>()
            .UseSqlServer(connString, builder => { builder.MigrationsHistoryTable("um_migrations", GetSchema()); });
        return optionsBuilder.Options;
    }
}