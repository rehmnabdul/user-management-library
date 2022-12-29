using UserManagementLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.AddUserManagement(builder.Configuration.GetConnectionString("ConnectionString")!);

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
app.MapRazorPages();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseUserManagement();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();