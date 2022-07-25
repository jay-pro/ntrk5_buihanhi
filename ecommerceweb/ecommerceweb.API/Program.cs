using ecommerceweb.API.Authorization;
using ecommerceweb.API.Data;
using ecommerceweb.API.Data.Repositories;
using ecommerceweb.API.Helpers;
using ecommerceweb.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AutoMapper;
using ecommerceweb.API.Services;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIDbContext>();
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnectionString")));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Add AutoMapper
{
    var services = builder.Services;
    var env = builder.Environment;
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnectionString")));
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddCors();
    services.AddControllers().AddJsonOptions(item =>
    {
        item.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());//serialize enums as strings in API responses
    });
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings")); //configure strongly typed settings object
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IAuthenticateService, Service>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //CORS      app.UseCors("corsapp");
    app.UseCors(item => item.AllowAnyHeader().AllowAnyMethod()
                                .SetIsOriginAllowed(origin => true)
                                .AllowCredentials());

    //Error Handler
    app.UseMiddleware<ErrorHandleMiddleware>();
    app.UseMiddleware<JwtMiddleware>();

    /*app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Resource", "ProductImages")),
        RequestPath = "/Product"
    });*/

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}


app.Run();
