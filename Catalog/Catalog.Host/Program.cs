using Catalog.Host.Configs;
using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var config = GetConfiguration();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(
        opt => opt.Filters.Add<HttpGlobalExceptionFilter>())
    .AddJsonOptions(opt => opt.JsonSerializerOptions.WriteIndented = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    opt =>
    {
        opt.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Version = "v1",
                Title = "CandyWebShop-Catalog API",
                Description = "The Catalog service HTTP API"
            });
    });

builder.Services.Configure<Config>(config);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IManufactureRepository, ManufactureRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IManufactureService, ManufactureService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();

builder.Services.AddDbContextFactory<CatalogDbContext>(opts => opts.UseNpgsql(config["ConnectionString"]));
builder.Services.AddScoped<IDbContextWrapper<CatalogDbContext>, DbContextWrapper<CatalogDbContext>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{config["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
    });

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endPoints =>
{
    endPoints.MapDefaultControllerRoute();
    endPoints.MapControllers();
});

CreateDbIfNotExists(app);
app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<CatalogDbContext>();

            CatalogDbInitializer.DataInitializer(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}