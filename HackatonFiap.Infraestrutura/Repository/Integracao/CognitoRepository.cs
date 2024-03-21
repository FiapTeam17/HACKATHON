using System.Text;
using System.Text.Json;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Dominio.Integracao.Cognito.Dtos;
using Microsoft.Extensions.Configuration;

namespace HackatonFiap.Infraestrutura.Repository.Integracao;

public class CognitoRepository : ICognitoRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CognitoRepository(
        IHttpClientFactory httpClientFactory, 
        IConfiguration configuration
    )
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
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
}