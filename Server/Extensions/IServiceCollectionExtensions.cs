using Microsoft.EntityFrameworkCore;
using Server.Repository;

namespace Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AdminLibrary(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(DbSet<>), typeof(NativeDbSet<>));

            return services;
        }
    }
}
