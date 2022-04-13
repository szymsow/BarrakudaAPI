namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}
