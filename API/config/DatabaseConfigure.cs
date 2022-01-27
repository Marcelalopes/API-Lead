using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.config
{
    public static class DatabaseConfigure
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            string connection = Configuration.GetConnectionString("conexaoMySQL");
            services.AddDbContextPool<AppDbContext>(
              options => options.UseMySql(
                connection, ServerVersion.AutoDetect(connection)
              )
            );
        }
    }
}