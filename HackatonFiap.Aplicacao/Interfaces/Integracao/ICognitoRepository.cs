using HackatonFiap.Dominio.Integracao.Cognito.Dtos;

namespace HackatonFiap.Aplicacao.Interfaces.Integracao;

public interface ICognitoRepository
{
    Task<LoginUsuarioDtoResponse?> Login(string usuario, string senha);
}