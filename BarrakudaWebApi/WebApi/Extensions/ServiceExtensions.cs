namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BarrakudaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("WebApi")));

            return builder;
        }

        public static IServiceCollection AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation();

            return services;
        }
        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            var authenticationSettings = new AuthenticationSettings();
            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            builder.Services.AddSingleton(authenticationSettings);
            return builder;
        }
        public static WebApplicationBuilder AddNlog(this WebApplicationBuilder builder)
        {
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            return builder;
        }
    }
}
