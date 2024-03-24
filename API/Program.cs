using API.Config;
using API.Controllers;
using API.Enums;
using API.Extensions;
using Asp.Versioning;

namespace API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Register();
        builder.Services.AddOutputCache(c =>
        {
            c.AddBasePolicy(build =>
            {
                build.Expire(TimeSpan.FromSeconds(3));
            });

            c.AddPolicyEnum(CachePolicy.Expire20, build =>
            {
                build.Expire(TimeSpan.FromSeconds(20));
            });
        });
        //builder.Services.AddStackExchangeRedisOutputCache(c =>
        //{
        //    c.Configuration = "localhost:6379";
        //    c.InstanceName = "SampleInstance";
        //});

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1);
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            opt.ReportApiVersions = false;
        })
        .AddApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'V";
            opt.SubstituteApiVersionInUrl = true;
        });

        builder.Services.ConfigureOptions<ConfigureSwaggerGen>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
        });

        var app = builder.Build();
        app.UseOutputCache();

        app.AddWeatherMinimalController();

        app.UseSwagger();
        app.UseSwaggerUI(opt =>
        {
            var descriptions = app.DescribeApiVersions();
            foreach (var description in descriptions)
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName.ToUpperInvariant();

                opt.SwaggerEndpoint(url, name);
            }
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}