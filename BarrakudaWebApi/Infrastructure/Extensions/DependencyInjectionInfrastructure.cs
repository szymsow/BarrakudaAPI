namespace Infrastructure.Extensions
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<BarrakudaWebApiSeeder>();
            return services;
        }
    }
}
