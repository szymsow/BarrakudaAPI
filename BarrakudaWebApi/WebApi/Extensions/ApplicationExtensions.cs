using WebApi.Middleware;

namespace WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseSwaggerConfig(this WebApplication application)
        {
            application.UseDeveloperExceptionPage();
            application.UseSwagger();
            application.UseSwaggerUI();
        }
        public static void AddMiddleware(this WebApplication application)
        {
            application.UseMiddleware<ErrorHandlingMiddleware>();
        }
        public static IServiceCollection AddBarrakudaServices(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();

            return services;
        }
        public static async Task Seed(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<BarrakudaWebApiSeeder>();

            await seeder.Seed();
        }
    }
}
