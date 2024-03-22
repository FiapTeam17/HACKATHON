using System.Text;
using System.Text.Json;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Integracao.Cognito.Dtos;
using HackatonFiap.Dominio.Integracao.Cognito.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HackatonFiap.Infraestrutura.Repository.Integracao;

public class CognitoRepository : ICognitoRepository
{
    private readonly HttpClient _httpClient;
    private readonly IAmazonCognitoIdentityProvider _cognitoIdentityProvider;
    private readonly IConfiguration _configuration;
    private readonly INotificador _notificador;
    private readonly ILogger<CognitoRepository> _logger;

    public CognitoRepository(
        IAmazonCognitoIdentityProvider cognitoIdentityProvider,
        IHttpClientFactory httpClientFactory, 
        IConfiguration configuration,
        INotificador notificador,
        ILogger<CognitoRepository> logger)
    {
        _httpClient = httpClientFactory.CreateClient();
        _cognitoIdentityProvider = cognitoIdentityProvider;
        _configuration = configuration;
        _notificador = notificador;
        _logger = logger;
    }
    
    public async Task<LoginUsuarioDtoResponse?> Login(string usuario, string senha)
    {
        var request = new LoginUsuarioDtoRequest
        {
            AuthFlow = "USER_PASSWORD_AUTH",
            ClientId = _configuration["Cognito:ClientLoginId"] ?? string.Empty,
            AuthParameters =
            {
                UserName = usuario,
                Passwrod = senha
            }
        };

        var url = _configuration["Cognito:LoginUser"];
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/x-amz-json-1.1");
        
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("X-Amz-Target", "AWSCognitoIdentityProviderService.InitiateAuth");
        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode) 
            return null;
        
        var body = await response.Content.ReadAsStringAsync();
        var resp = JsonSerializer.Deserialize<LoginUsuarioDtoResponse>(body);
        return resp;
    }

    public async Task<CognitoUserModel?> Adicionar(CognitoUserModel cognitoUserModel)
    {
        try
        {
            var userSignUpRequest = new SignUpRequest
            {
                ClientId = "7j95cu6i1d3m8pnddmdrqov8a8",//_configuration["Cognito:ClientId"],
                Password = cognitoUserModel.Password,
                Username = cognitoUserModel.Email
            };
        
            var attributeName = new AttributeType
            {
                Name = "name",
                Value = cognitoUserModel.Name
            };
            userSignUpRequest.UserAttributes.Add(attributeName);
            
            var userAttrs = new AttributeType
            {
                Name = "email",
                Value = cognitoUserModel.Email
            };
            userSignUpRequest.UserAttributes.Add(userAttrs);
        
            var userCreated = await _cognitoIdentityProvider.SignUpAsync(userSignUpRequest);
            
            if (userCreated == null) 
                return null;
            
            cognitoUserModel.UserSub = userCreated.UserSub;
            return cognitoUserModel;

        }
        catch (Exception e)
        {
            _notificador.Notificar("Não foi possível adicionar o usuário!");
            _logger.LogError(e, "{Message}, {InnerException}, {StackTrace}", e.Message, e.InnerException?.Message,e.StackTrace);
            return null;
        }
    }
}