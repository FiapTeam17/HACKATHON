namespace HackatonFiap.Dominio.Autenticacao.Dtos;

public class AutenticacoLoginDtoRetorno
{    
    public int ExpiresIn { get; set; }
    public string IdToken { get; set; } = string.Empty;
}