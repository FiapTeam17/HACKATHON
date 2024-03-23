using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.UserCases;
using Microsoft.Extensions.DependencyInjection;

namespace HackatonFiap.Aplicacao;

public static class ConfiguracaoServicos
{
    public static IServiceCollection AddAplicacao(this IServiceCollection services)
    {
        services.AddScoped<IAutenticacaoUseCase, AutenticacaoUseCase>();
        services.AddScoped<IFuncionarioUseCase, FuncionarioUseCase>();
        services.AddScoped<IPontoUseCase, PontoUseCase>();
        services.AddScoped<ISolicitaRelatorioPontoUseCase, SolicitaRelatorioPontoUseCase>();

        return services;

    }
}
