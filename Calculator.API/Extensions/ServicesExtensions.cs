using Calculator.API.Services;
using Calculator.Service.Resolver;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorService, CalculatorService>();
            services.AddTransient<IComputeResolver, ComputeResolver>();
        }
    }
}
