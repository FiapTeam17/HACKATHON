using System.Text.Json.Serialization;

namespace HackatonFiap.Dominio.Integracao.Cognito.Dtos;

public class LoginUsuarioDtoRequest
{
    public AuthParametersDto AuthParameters { get; set; } = new AuthParametersDto();
    public string AuthFlow { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
}

public class AuthParametersDto
{
    [JsonPropertyName("USERNAME")] 
    public string UserName { get; set; } = string.Empty;
    [JsonPropertyName("PASSWORD")]
    public string Passwrod { get; set; } = string.Empty;
}