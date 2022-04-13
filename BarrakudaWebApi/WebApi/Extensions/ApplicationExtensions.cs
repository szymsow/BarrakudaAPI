namespace WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseSwaggerConfig(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }
    }
}
