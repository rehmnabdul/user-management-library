using Microsoft.EntityFrameworkCore;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.DB;

public class DbUserManagement : DbContext
{
    public static async Task<DbUserManagement> Init(string connString)
    {
        var userManagement = new DbUserManagement(DbUserManagementDesign.GetDbOptions(connString));
        await userManagement.Database.MigrateAsync();
        await userManagement.SaveChangesAsync();
        return userManagement;
    }

    public DbUserManagement(DbContextOptions<DbUserManagement> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserAuth> UsersAuths { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;
    public DbSet<Gender> Gender { get; set; } = default!;
    public DbSet<City> Cities { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbUserManagementDesign.GetSchema());
    }
}