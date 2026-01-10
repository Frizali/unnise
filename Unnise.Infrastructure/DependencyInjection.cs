using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Infrastructure.Persistence;
using Unnise.Infrastructure.Repositories;
using Unnise.Infrastructure.Security;

namespace Unnise.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UnniseDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtKey = configuration["Jwt:Key"];
                if (string.IsNullOrEmpty(jwtKey))
                    throw new InvalidOperationException("JWT key is not configured.");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });
            services.AddHttpContextAccessor();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
