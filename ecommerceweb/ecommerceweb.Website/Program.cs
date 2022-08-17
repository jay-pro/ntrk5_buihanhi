using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AspNetCoreHero.ToastNotification;
using Microsoft.Net.Http.Headers;//
using System.Text.Json.Serialization;
using ecommerceweb.API.Helpers;
using ecommerceweb.API.Authorization;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Services;
using ecommerceweb.Website.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using ecommerceweb.API.Data.Repositories;
using ecommerceweb.API.Data;

var builder = WebApplication.CreateBuilder(args);
//var env = builder.Environment;
//var configuration = builder.Configuration;

// Add services to the container.
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
    builder.Services.AddNotyf(configure => { configure.DurationInSeconds = 10; configure.Position = NotyfPosition.BottomRight; });
    //builder.Services.AddDbContext<EcommerceWebContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbEcommerceweb")));
    builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//
    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });//
    //builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApiConnectionString"));//
    builder.Services.AddMvc().AddSessionStateTempDataProvider();
    builder.Services.AddSession();

    builder.Services.AddDbContext<APIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnectionString"))
    );
    //Dependency Injection
    //builder.Services.AddScoped<IJwtUtils, JwtUtils>();
    //builder.Services.AddTransient<IAuthenticateService, Service>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IRatingRepository, RatingRepository>();
    builder.Services.AddScoped<IAccountRepository, AccountRepository>();

    builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));//
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();
//app.Use(async (context, next) =>
//{
//    var token = context.Session.GetString("Token");
//    if (!string.IsNullOrEmpty(token))
//    {
//        context.Request.Headers.Add("Authorization", "Bearer " + token);
//    }
//    await next();
//});
app.UseCors("corsapp");//

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<ErrorHandleMiddleware>();
//app.UseMiddleware<JwtMiddleware>();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
