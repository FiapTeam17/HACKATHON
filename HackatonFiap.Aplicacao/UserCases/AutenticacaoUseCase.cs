using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Autenticacao.Dtos;

namespace HackatonFiap.Aplicacao.UserCases;

public class AutenticacaoUseCase : IAutenticacaoUseCase
{
    private readonly ICognitoRepository _cognitoRepository;
    private readonly INotificador _notificador;

    public AutenticacaoUseCase(
        ICognitoRepository cognitoRepository,
        INotificador notificador
        )
    {
        _cognitoRepository = cognitoRepository;
        _notificador = notificador;
    }
    
    public async Task<AutenticacoLoginDtoRetorno?> Login(AutenticacoLoginDto autenticacoLoginDto)
    {
        var resp = await _cognitoRepository.Login(autenticacoLoginDto.Email, autenticacoLoginDto.Senha).ConfigureAwait(false);
        if (resp != null)
            return new AutenticacoLoginDtoRetorno
            {
                IdToken = resp.AuthenticationResult.IdToken,
                ExpiresIn = resp.AuthenticationResult.ExpiresIn
            };
                
        
        _notificador.Notificar("Não foi possível realizar o login!");
        return null;

    }
}