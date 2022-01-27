using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace API.config
{
    public static class ControllerConfig
    {
        public static void AddController(this IServiceCollection services)
        {
            services
               .AddControllers()
               .AddJsonOptions(options =>
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
               );
        }
    }
}