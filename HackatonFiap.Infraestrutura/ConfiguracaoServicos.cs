using Amazon.CognitoIdentityProvider;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Extensions;
using HackatonFiap.Infraestrutura.Context;
using HackatonFiap.Infraestrutura.Repository;
using HackatonFiap.Infraestrutura.Repository.Integracao;
using HackatonFiap.Infraestrutura.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HackatonFiap.Infraestrutura;

public static class ConfiguracaoServicos
{
    public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
    {
        var varDbServer = configuration.GetValue<string>("DbServer");
        string? dbServer = string.IsNullOrEmpty(varDbServer) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(varDbServer);
            
        var varDbUser = configuration.GetValue<string>("DbUser");
        string? dbUser = string.IsNullOrEmpty(varDbUser) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(varDbUser);
            
        var varDbPass = configuration.GetValue<string>("DbPass");
        string? dbPass = string.IsNullOrEmpty(varDbPass) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(varDbPass);
            
        var varDbSchema = configuration.GetValue<string>("DbSchema");
        string? dbSchema = string.IsNullOrEmpty(varDbSchema) ? string.Empty : UtilExtension.GetDecodedEnvironmentVariable(varDbSchema);
            
        var connectionString = configuration.GetConnectionString("ConnectionString");
        connectionString = connectionString?.Replace("[DB_SERVER]", dbServer);
        connectionString = connectionString?.Replace("[DB_USER]", dbUser);
        connectionString = connectionString?.Replace("[DB_PASS]", dbPass);
        connectionString = connectionString?.Replace("[DB_SCHEMA]", dbSchema);

        if (connectionString == null)
        {
            throw new Exception("String de conexão não encontrada!");
        }

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMySQL(connectionString, op => op.CommandTimeout(600));
        });
        
        services.AddAWSService<IAmazonCognitoIdentityProvider>();
        
        services.AddScoped<DatabaseContext>();
        services.AddScoped<DbContext, DatabaseContext>();
        
        services.AddScoped<ICognitoRepository, CognitoRepository>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
<<<<<<< HEAD
        services.AddScoped<IPontoRepository, PontoRepository>();
        services.AddScoped<ITransactionService, TransactionService>();            
=======
        services.AddScoped<ITransactionService, TransactionService>();
>>>>>>> 7fa9c1e1fdc197980e9a1d670330ad4a493e61c3

        return services;
    }
}