using Microsoft.EntityFrameworkCore;

namespace UserManagementLibrary.Utils;

public static class DbContextOptions
{
    public static string? GetSchemaName(this DbContext context, Type type)
    {
        return context.Model.FindEntityType(type)?.GetSchema();
    }
    public static string? GetTableName(this DbContext context, Type type)
    {
        return context.Model.FindEntityType(type)?.GetTableName();
    }
}