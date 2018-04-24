using Core.Services;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{

    public static class DataDependencyInstaller
    {
        public static void InstallDalDependencies(this IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opt => opt.UseInMemoryDatabase("Aurelia"));
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
