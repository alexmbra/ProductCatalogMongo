using ProductApi.Data;

namespace ProductApi.Services;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register ProductContext for MongoDB
        //services.AddScoped<ProductContext>(provider =>
        //{
        //    var connectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value;
        //    var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;
        //    return new ProductContext(configuration);
        //});

        services.AddScoped<IProductContext, ProductContext>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

}
