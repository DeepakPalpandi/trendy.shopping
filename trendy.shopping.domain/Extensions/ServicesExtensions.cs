using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using trendy.shopping.domain.Helpers;

namespace trendy.shopping.domain.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection CustomAddCors(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(
                        configuration?.GetValue<string>("CorsOrigins")!.Split(";") ?? new[] { string.Empty })
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static IMvcBuilder CustomAddControllers(this IServiceCollection services)
        {
            return services.AddControllers(options =>
                            options.Conventions.Add(
                                new RouteTokenTransformerConvention(new SlugifyParameterTransformer())))
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                            options.JsonSerializerOptions.AllowTrailingCommas = true;
                        });
        }

        public static IServiceCollection CustomAddDBContext<T>(this IServiceCollection services,
            string connectionString, string? migrationAssembly = null) where T : DbContext
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            return services.AddDbContext<T>(options =>
            {
                //options.UseNpgsql(connectionString)
                options.UseNpgsql(connectionString, b =>
                {
                    if (!string.IsNullOrEmpty(migrationAssembly))
                        b.MigrationsAssembly(migrationAssembly);
                    b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                })
               .UseSnakeCaseNamingConvention();
            });
        }

        public static WebApplicationBuilder CustomAddSeriLog(this WebApplicationBuilder builder,
        IConfiguration configuration, string connectionString, string? tableName = "Logs")
        {
            var logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(configuration)
                                .WriteTo.PostgreSQL(
                                    connectionString: connectionString,
                                    tableName: tableName,
                                    needAutoCreateTable: true,
                                    batchSizeLimit: 1)
                                .Enrich.FromLogContext()
                                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            return builder;
        }

        public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        options.TokenValidationParameters = GetTokenValidationParameters(configuration);
                    });

            return services;
        }

        private static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["jwt:Audience"],
                ValidIssuer = configuration["jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Key"]!))
            };
        }
    }
}
