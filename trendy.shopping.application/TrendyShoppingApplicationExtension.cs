using Microsoft.Extensions.DependencyInjection;
using trendy.shopping.application.CommonMethods;
using trendy.shopping.application.Services;
using trendy.shopping.domain.Data;
using trendy.shopping.domain.Extensions;
using trendy.shopping.domain.UnitOfWork;

namespace trendy.shopping.application;

public static class TrendyShoppingApplicationExtension
{
    public static IServiceCollection AddTrendyShoppingApplication(this IServiceCollection services,
    string connectionString,
        string assemblyName)
    {
        #region DB Context
        services.CustomAddDBContext<TrendyShoppingContext>(connectionString, assemblyName);
        #endregion

        #region Services
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ICustomerService, CustomerService>();
        #endregion

        #region Repositories
        #endregion


        services.AddScoped<ITrendyShoppingUnitOfWork, TrendyShoppingUnitOfWork>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
