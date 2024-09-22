
using System.Security.Cryptography.X509Certificates;
using Microsoft.OpenApi.Models;
using ProductApi.Services;

namespace ProductApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.RegisterServices(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoProductAPI", Version = "v1" });
        });

        //// Check if the app is running in a Docker container
        //if (builder.Environment.IsDevelopment())
        //{
        //    builder.WebHost.ConfigureKestrel(options =>
        //    {
        //        // HTTPS is enabled in development (local)
        //        options.ListenAnyIP(8080); // HTTP port
        //        options.ListenAnyIP(8001, listenOptions =>
        //        {
        //            listenOptions.UseHttps();
        //        });
        //    });
        //}
        //else
        //{
        //    // Disable HTTPS for Docker environment
        //    builder.WebHost.ConfigureKestrel(options =>
        //    {
        //        options.ListenAnyIP(8080); // Only HTTP in Docker
        //    });
        //}

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                listenOptions.ServerCertificate = new X509Certificate2("https/ProductCatalogMongo.pfx", "Numsey2024");
            });
        });


        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
