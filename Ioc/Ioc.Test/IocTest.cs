
using Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository;
using Service.Interface;
using Service;

namespace Ioc.Test
{
    public static class IocTest
    {
        /// <summary>
        /// Configure repository injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }


        /// <summary>
        /// Configure service injection
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMaterialService, MaterialService>();

            return services;
        }


        /// <summary>
        /// Configuring the in-memory database connection for the test environment
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<ItemMicroServiceIDbContext, ItemMicroServiceDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestApplication")
                );

            return services;
        }
    }
}
