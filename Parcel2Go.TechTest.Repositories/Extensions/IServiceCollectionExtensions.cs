using Microsoft.Extensions.DependencyInjection;
using Parcel2Go.TechTest.Interfaces;

namespace Parcel2Go.TechTest.Repositories.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInventoryRepository, HardCodedInventoryRepository>();
        }
    }
}
