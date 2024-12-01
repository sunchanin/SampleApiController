using System;
using Microsoft.EntityFrameworkCore;
using SampleApiController.Data;
using SampleApiController.Interfaces;
using SampleApiController.Services;

namespace SampleApiController.Extensions;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}


