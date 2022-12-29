using EasyData.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagementLibrary.DB;

namespace UserManagementLibrary;

public static class UserManagementInterface
{
    public static void AddUserManagement(this WebApplicationBuilder builder, string connectionString)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<DbUserManagement>(options => { options.UseSqlServer(connectionString); });
    }

    public static void UseUserManagement(this WebApplication app)
    {
        app.MapRazorPages();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapEasyData(options =>
            {
                options.UseDbContext<DbUserManagement>();
            });
        });
    }
}