using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));
builder.Services.ConfigureWritable<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddIdentity<AppUser,AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    // User Username and Email Options
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<SerdehaBlogDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        Name = "SerdehaBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.ExpireTimeSpan = TimeSpan.FromDays(14);
});
builder.Services.AddDbContext<SerdehaBlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SerdehaBlog")));
builder.Services.AddServices();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(14);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute("default", "{controller=Blog}/{action=Index}/{id?}");
app.MapControllerRoute("article", "{title}/{articleId}", new { controller = "Blog", action = "ReadMore", Area = "" });

app.Run();
