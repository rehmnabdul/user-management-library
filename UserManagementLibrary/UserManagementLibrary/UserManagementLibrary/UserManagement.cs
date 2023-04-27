using Microsoft.EntityFrameworkCore;
using UserManagementLibrary.DB;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utils;

namespace UserManagementLibrary;

public static class UserManagement
{
    private static DbUserManagement DbUserManagement { set; get; } = null!;

    public static async Task Init(string connectionString)
    {
        DbUserManagement = await DbUserManagement.Init(connectionString);
    }


    public static async Task<Result<User>> GetUserById(int id)
    {
        var user = await DbUserManagement.Users.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return user == null ? Result<User>.Failure("User Not Found") : Result<User>.Success("Success", user);
    }

    public static async Task<Result<User>> GetUserByUid(string uid)
    {
        var user = await DbUserManagement.Users.Where(e => e.Uid == uid).AsNoTracking().FirstOrDefaultAsync();
        return user == null ? Result<User>.Failure("User Not Found") : Result<User>.Success("Success", user);
    }

    public static async Task<Result<User>> GetUserByEmail(string email)
    {
        var user = await DbUserManagement.Users.Where(e => e.Email == email).AsNoTracking().FirstOrDefaultAsync();
        return user == null ? Result<User>.Failure("User Not Found") : Result<User>.Success("Success", user);
    }


    public static async Task<Result<User>> CreateUser(User user, string password)
    {
        if (user.Id != 0)
        {
            return Result<User>.Failure($"ID must be empty: ID({user.Id}) must be empty to create a new user");
        }

        await using var trans = await DbUserManagement.Database.BeginTransactionAsync();
        try
        {
            var userEntity = await user.SaveNow(DbUserManagement);

            Crypto.CreatePasswordHash(password, out var passHash, out var keyHash);
            var userAuth = new UserAuth
            {
                User = (userEntity.Entity as User)!,
                PassHash = passHash,
                PassKey = keyHash
            };

            await userAuth.SaveNow(DbUserManagement);
            await trans.CommitAsync();

            return Result<User>.Success("Success", (userEntity.Entity as User)!);
        }
        catch (Exception e)
        {
            await trans.RollbackAsync();
            return Result<User>.Failure(e.Message, e);
        }
    }

    public static async Task<Result<User>> UpdateUserName(User user)
    {
        if (user.Id == 0) return Result<User>.Failure("User ID Empty: User ID can't be empty");

        var prev = await GetUserById(user.Id);
        if (prev.Data == null)
        {
            return Result<User>.Failure($"User Not Found: No such user exists that have this particular ID({user.Id}) in the database");
        }

        prev.Data.FirstName = user.FirstName;
        prev.Data.MiddleName = user.MiddleName;
        prev.Data.LastName = user.LastName;

        await prev.Data.SaveNow(DbUserManagement);

        return prev;
    }

    public static async Task<Result<object>> UpdateUserPassword(int id, string newPassword)
    {
        var auth = await DbUserManagement.UsersAuths.FindAsync(id);
        if (auth == null)
        {
            return Result<object>.Failure($"No Auth Found: User Auth not found against ID{id}");
        }

        Crypto.CreatePasswordHash(newPassword, out var passHash, out var keyHash);
        auth.PassHash = passHash;
        auth.PassKey = keyHash;

        await auth.SaveNow(DbUserManagement);

        return Result<object>.Success("Success", true);
    }

    public static async Task<Result<User>> UpdateUserEmail(int id, string email)
    {
        var result = await GetUserById(id);
        if (result.Data == null)
        {
            return Result<User>.Failure($"User Not Found: User doesn't exists against this ID{id}");
        }

        result.Data.Email = email;
        await result.Data.SaveNow(DbUserManagement);

        return Result<User>.Success("Success", result.Data);
    }
}