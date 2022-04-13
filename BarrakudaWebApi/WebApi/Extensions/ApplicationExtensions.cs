namespace WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseSwaggerConfig(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }
        public static async Task Seed(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<BarrakudaWebApiSeeder>();

            await seeder.Seed();
        }
    }
}
