using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using trendy.shopping.application;
using trendy.shopping.domain.Data;
using trendy.shopping.domain.Exceptions;
using trendy.shopping.domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.CustomAddControllers();

configuration.AddEnvironmentVariables("TRENDY_");

string connectionString = configuration.GetValue<string>("ConnectionString") ?? string.Empty;

string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;

builder.Services.CustomAddCors(configuration);

Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

builder.Services.AddTrendyShoppingApplication(connectionString, assemblyName);

builder.CustomAddSeriLog(configuration, connectionString);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureJwtAuthentication(configuration);

var app = builder.Build();

app.MigrateDatabase<TrendyShoppingContext>();

app.CustomUseSwagger();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.CustomUseForwardedHeaders();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
