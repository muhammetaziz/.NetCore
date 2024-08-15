using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);


//Authorize i�lemleri
void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    services.AddSession();

    services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

        config.Filters.Add(new AuthorizeFilter(policy));

    });
    services.AddMvc();
    services.AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
        {
            x.LoginPath = "/Login/Index";
        });
}


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");


app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );


app.Run();