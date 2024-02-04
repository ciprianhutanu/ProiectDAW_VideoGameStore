using ProiectDAW_VideoGameStore.Helpers.JwtUtils;
using ProiectDAW_VideoGameStore.Repositories.UserRepository;
using ProiectDAW_VideoGameStore.Services.UserServices;

namespace ProiectDAW_VideoGameStore.Helpers.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtil>();

            return services;
        }
    }
}
