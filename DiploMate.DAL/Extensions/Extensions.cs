using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiploMate.DAL.Extensions;

public static class Extensions
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"), b=>b.MigrationsAssembly("DiploMate")
            ));
        return services;
    }
    
}