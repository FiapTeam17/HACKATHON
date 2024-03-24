namespace HackatonFiap.Dominio.Integracao.Cognito.Models;

public class CognitoUserModel
{
    public string UserSub { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}