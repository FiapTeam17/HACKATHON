using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.UserCases;
using Microsoft.Extensions.DependencyInjection;

namespace HackatonFiap.Aplicacao;

    public static class ConfiguracaoServicos
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioUseCase, FuncionarioUseCase>();

            return services;
        }
    }
