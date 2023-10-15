using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WIL_Project.Areas.Identity.Data;
using WIL_Project.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

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

// Add this part to configure routing for your login and registration controllers
app.MapControllerRoute(
    name: "login",
    pattern: "Login/{action=Index}/{id?}",
    defaults: new { controller = "Login" });

app.MapControllerRoute(
    name: "register",
    pattern: "Register/{action=Index}/{id?}",
    defaults: new { controller = "Register" });

app.MapRazorPages();

app.Run();
