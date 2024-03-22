using HackatonFiap.Dominio.Integracao.Cognito.Dtos;
using HackatonFiap.Dominio.Integracao.Cognito.Models;

namespace HackatonFiap.Aplicacao.Interfaces.Integracao;

public interface ICognitoRepository
{
    Task<LoginUsuarioDtoResponse?> Login(string usuario, string senha);
    Task<CognitoUserModel?> Adicionar(CognitoUserModel cognitoUserModel);
}