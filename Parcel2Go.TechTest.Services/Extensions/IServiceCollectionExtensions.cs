using Microsoft.Extensions.DependencyInjection;
using Parcel2Go.TechTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go.TechTest.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICostCalculationService, CostCalculationService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
        }
    }
}
