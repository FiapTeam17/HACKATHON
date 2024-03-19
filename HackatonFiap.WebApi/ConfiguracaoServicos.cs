using HackatonFiap.Comum;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;

namespace HackatonFiap;

    public static class ConfiguracaoServicos
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, User>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
