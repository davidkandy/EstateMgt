using Microsoft.EntityFrameworkCore;
using Server.Repository;

namespace Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AdminLibrary(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(DbSet<>), typeof(NativeDbSet<>));

            return services;
        }
    }
}
