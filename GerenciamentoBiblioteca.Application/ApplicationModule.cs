using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciamentoBiblioteca.Application.Validators;
using GerenciamentoBiblioteca.Core.Repositories;
using GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoBiblioteca.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServiceRepository();
            services.AddServiceValidation();
            return services;
        }

        private static IServiceCollection AddServiceRepository(this IServiceCollection services)
        {
            services.AddScoped<ILivrosRepository, LivrosRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            return services;
        }

        private static IServiceCollection AddServiceValidation(this IServiceCollection services) {
            services
                .AddValidatorsFromAssemblyContaining<CadastrarEmprestimoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
