namespace HackatonFiap.Dominio.Integracao.Cognito.Dtos;

public class LoginUsuarioDtoResponse
{
    public AuthenticationResultDto AuthenticationResult { get; set; } = new AuthenticationResultDto();
    // public object ChallengeParameters { get; set; }
}

public class AuthenticationResultDto
{
    public string AccessToken { get; set; } = string.Empty;
    public int ExpiresIn { get; set; }
    public string IdToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string TokenType { get; set; } = string.Empty;
}