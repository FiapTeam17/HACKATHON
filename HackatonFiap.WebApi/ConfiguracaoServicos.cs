using HackatonFiap.Comum;
using HackatonFiap.Comum.Extensions;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;

namespace HackatonFiap;

public static class ConfiguracaoServicos
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        var confRegion = configuration["Cognito:Region"];
        string vaRegion = string.IsNullOrEmpty(confRegion) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(confRegion);
        configuration["Cognito:Region"] = vaRegion;

        var confUserPool = configuration["Cognito:UserPoolId"];
        string vaUserpool = string.IsNullOrEmpty(confUserPool) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(confUserPool);
        configuration["Cognito:UserPoolId"] = vaUserpool;

        var confAuthority = configuration["Cognito:Authority"];
        confAuthority = confAuthority?.Replace("[AWS_REGION]", vaRegion);
        confAuthority = confAuthority?.Replace("[USER_POOL_ID]", vaUserpool);
        configuration["Cognito:Authority"] = confAuthority;

        var confClientLoginId = configuration["Cognito:ClientLoginId"];
        string vaClientLoginId = string.IsNullOrEmpty(confClientLoginId) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(confClientLoginId);
        configuration["Cognito:ClientLoginId"] = vaClientLoginId;

        var confClientId = configuration["Cognito:ClientId"];
        string vaClientId = string.IsNullOrEmpty(confClientId) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(confClientId);
        configuration["Cognito:ClientId"] = vaClientId;

        var confLoginUser = configuration["Cognito:LoginUser"];
        configuration["Cognito:LoginUser"] = confLoginUser?.Replace("[AWS_REGION]", vaRegion);

        var awsClientId = configuration["aws:ClientId"];
        string vaAwsClientId = string.IsNullOrEmpty(awsClientId) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(awsClientId);
        configuration["aws:ClientId"] = vaAwsClientId;

        var awsClientSecret = configuration["aws:ClientSecret"];
        string vaAwsClientSecret = string.IsNullOrEmpty(awsClientSecret) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(awsClientSecret);
        configuration["aws:ClientSecret"] = vaAwsClientSecret;

        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IUser, User>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}
