using System.Security.Claims;
using Domain.Models.Entities;
using LMS.API.Extensions;
using LMS.Infrastructure.Data;
using LMS.Presemtation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<LmsContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("LmsContext")
                    ?? throw new InvalidOperationException(
                        "Connection string 'CompaniesContext' not found."
                    )
            )
        );

        builder
            .Services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
            })
            .AddNewtonsoftJson()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);

        builder.Services.ConfigureOpenApi();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.ConfigureServiceLayerServices();
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureJwt(builder.Configuration);
        builder.Services.ConfigureCors();

        builder
            .Services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<LmsContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<PasswordHasherOptions>(options =>
            options.IterationCount = 10000
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            await app.SeedDataAsync();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
