using ProiectDAW_VideoGameStore.Helpers.JwtUtils;
using ProiectDAW_VideoGameStore.Helpers.Seeders;
using ProiectDAW_VideoGameStore.Repositories.OrderRepository;
using ProiectDAW_VideoGameStore.Repositories.PlacedOnRepository;
using ProiectDAW_VideoGameStore.Repositories.ReviewRepository;
using ProiectDAW_VideoGameStore.Repositories.StoreItemRepository;
using ProiectDAW_VideoGameStore.Repositories.UserRepository;
using ProiectDAW_VideoGameStore.Services.OrderServices;
using ProiectDAW_VideoGameStore.Services.StoreItemServices;
using ProiectDAW_VideoGameStore.Services.UserServices;

namespace ProiectDAW_VideoGameStore.Helpers.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IStoreItemRepository, StoreItemRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IPlacedOnRepository, PlacedOnRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IStoreItemServices, StoreItemServices>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtil>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<StoreItemSeeder>();
            return services;
        }
    }
}
