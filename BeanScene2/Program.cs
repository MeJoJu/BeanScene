global using BeanScene2.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeanScene2.Data;
using BeanScene2.Data.Services;
using Microsoft.AspNetCore.Identity;
using BeanScene2.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeanScene2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeanScene2Context") ?? throw new InvalidOperationException("Connection string 'BeanScene2Context' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BeanScene2Context>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<BeanScene2Context>()
       .AddDefaultTokenProviders();

//Services configuration
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IUserService, UserService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddDbContext<BeanScene2DbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection"))
//    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
