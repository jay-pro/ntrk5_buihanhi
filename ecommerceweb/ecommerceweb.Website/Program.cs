using ecommerceweb.Website.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AspNetCoreHero.ToastNotification;
using Microsoft.Net.Http.Headers;//


var builder = WebApplication.CreateBuilder(args);
var stringConnectdb = builder.Configuration.GetConnectionString("dbEcommerceweb");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(configure => { configure.DurationInSeconds = 10; configure.Position = NotyfPosition.BottomRight; });
builder.Services.AddDbContext<EcommerceWebContext>(options => options.UseSqlServer(stringConnectdb));
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllHeadersPolicy",
        policy =>
        {
            policy.WithOrigins("https://localhost:44446","https://localhost:3000")
                   .AllowAnyHeader();
        });
});*/

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:44303")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});*/

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));//

/*builder.Services.AddControllers();*///

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("corsapp");//

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

/*app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());*/
/*app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());*/


app.UseAuthorization();

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
