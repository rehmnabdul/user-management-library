using Microsoft.EntityFrameworkCore;

namespace UserManagementWebDemo.Models;

public class DbUserManagement : DbContext
{
    public DbUserManagement(DbContextOptions<DbUserManagement> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserAuth> UsersAuths { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;
    public DbSet<Gender> Gender { get; set; } = default!;
    public DbSet<City> Cities { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Test> Tests { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbUserManagementDesign.GetSchema());
        modelBuilder.Entity<Test>().HasNoKey();
    }
}