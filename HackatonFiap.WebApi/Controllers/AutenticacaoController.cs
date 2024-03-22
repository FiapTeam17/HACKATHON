using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Autenticacao.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonFiap.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AutenticacaoController : BaseController
{
    private readonly IAutenticacaoUseCase _autenticacaoUseCase;

    public AutenticacaoController(
        IAutenticacaoUseCase autenticacaoUseCase,
        INotificador notificador
    )  : base(notificador)
    {
        _autenticacaoUseCase = autenticacaoUseCase;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<AutenticacoLoginDtoRetorno>> Login(AutenticacoLoginDto autenticacoLoginDto)
    {
        var result = await _autenticacaoUseCase.Login(autenticacoLoginDto);
        return CustomResponse(result);
    }
}