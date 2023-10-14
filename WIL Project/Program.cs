using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WIL_Project.Areas.Identity.Data;
using WIL_Project.DBContext; // Add the appropriate using statement for your DbContext
using Microsoft.Extensions.Configuration; // Add the using statement for Configuration
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection") ?? throw new InvalidOperationException("Connection string 'MySqlConnection' not found.");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SampleUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
