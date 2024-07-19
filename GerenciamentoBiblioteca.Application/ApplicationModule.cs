using GerenciamentoBiblioteca.Core.Repositories;
using GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoBiblioteca.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServices();
            return services;    
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILivrosRepository, LivrosRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
