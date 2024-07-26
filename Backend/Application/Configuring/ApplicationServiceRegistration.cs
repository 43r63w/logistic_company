using Application.Configuring.Jwt;
using Application.Configuring.Profile;
using Application.IServices;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuring
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<JwtGenerator>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
