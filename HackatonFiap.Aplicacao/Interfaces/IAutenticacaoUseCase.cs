using HackatonFiap.Dominio.Autenticacao.Dtos;

namespace HackatonFiap.Aplicacao.Interfaces;

public interface IAutenticacaoUseCase
{
    Task<AutenticacoLoginDtoRetorno?> Login(AutenticacoLoginDto autenticacoLoginDto);
}