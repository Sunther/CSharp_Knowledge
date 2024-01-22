using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Auth
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorizationBuilder();
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite("Data Source = DataSource-app.db"));
        builder.Services.AddIdentityCore<MyUser>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddApiEndpoints();

        var app = builder.Build();

        // Auth
        app.MapIdentityApi<MyUser>();

        app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}")
            .RequireAuthorization();

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