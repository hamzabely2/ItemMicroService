
using Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.ConfigureInjectionDependencyRepository();

            return services;
        }


        /// <summary>
        /// Configure service injection
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.ConfigureInjectionDependencyService();

            return services;
        }


        /// <summary>
        /// Configuring the in-memory database connection for the test environment
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            return services.AddDbContext<ItemMicroServiceIDbContext, ItemMicroServiceDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });
        }
    }
}
