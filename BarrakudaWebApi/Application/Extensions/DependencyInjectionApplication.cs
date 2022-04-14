using Application.Validators.Product;

namespace Application.Extensions
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();

            return services;
        }
    }
}
