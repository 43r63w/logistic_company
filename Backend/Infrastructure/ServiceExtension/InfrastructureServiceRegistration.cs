using Infrastructure.Context;
using Infrastructure.GenericRepository;
using Infrastructure.IGenericRepository;
using Infrastructure.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceExtension
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
                         {
                             options.UseNpgsql(configuration.GetConnectionString("DockerDbConnection"));
                         });
        }

        public static void ApplyMigration(this IApplicationBuilder applicationBuilder)
        {

            using var service = applicationBuilder.ApplicationServices.CreateScope();
            using var dbContext = service.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.EnsureCreated();
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }



    }
}
