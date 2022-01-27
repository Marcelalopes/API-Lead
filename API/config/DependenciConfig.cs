using API.Repository;
using API.Repository.Interfaces;
using API.Services;
using API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.config
{
    public static class DependenciConfig
    {
        public static void AddDependeci(this IServiceCollection services)
        {
            services.AddScoped<ICollaboratorService, CollaboratorService>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}