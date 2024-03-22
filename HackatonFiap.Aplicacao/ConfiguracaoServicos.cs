using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.UserCases;
using Microsoft.Extensions.DependencyInjection;

namespace HackatonFiap.Aplicacao;

public static class ConfiguracaoServicos
{
    public static IServiceCollection AddAplicacao(this IServiceCollection services)
    {
<<<<<<< HEAD
        services.AddScoped<IFuncionarioUseCase, FuncionarioUseCase>();
        services.AddScoped<IPontoUseCase, PontoUseCase>();
=======
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IAutenticacaoUseCase, AutenticacaoUseCase>();
            services.AddScoped<IFuncionarioUseCase, FuncionarioUseCase>();
>>>>>>> 7fa9c1e1fdc197980e9a1d670330ad4a493e61c3

        return services;
    }
}
