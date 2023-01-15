using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.Cookie.SameSite = SameSiteMode.Strict; // cookie nin sadece ilgili domainde calistirir
    opt.Cookie.HttpOnly = true; // cookie nin javascript ile paylasimi engeller
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //istek ne(http or https) ile gelirse �yle karsila
    opt.Cookie.Name = "UpSchoolApiConsumeProjectCookie";
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
