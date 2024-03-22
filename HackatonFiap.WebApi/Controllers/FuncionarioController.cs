using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Funcionario.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HackatonFiap.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : BaseController
{
    private readonly IFuncionarioUseCase _funcionarioUseCase;
    private readonly ILogger<FuncionarioController> _logger;
    private readonly IUser _user;

    public FuncionarioController(
        IFuncionarioUseCase funcionarioUseCase,
        ILogger<FuncionarioController> logger,
        IUser user,
        INotificador notificador
    )  : base(notificador)
    {
        _funcionarioUseCase = funcionarioUseCase;
        _logger = logger;
        _user = user;
    }
    
    [HttpGet()]
    public async Task<ActionResult<ListaPaginada<FuncionarioDtoRetorno>>> ObterTodos(
        [FromQuery] string filtro = "", 
        [FromQuery] string ordenacao = "id asc", 
        [FromQuery] int pagina = 1, 
        [FromQuery] int qtdeRegistros = 10)
    {
        var email = _user.GetUserEmail();
        var funcionarios = await _funcionarioUseCase.Listar(filtro, ordenacao,
            pagina, qtdeRegistros);
        return CustomResponse(funcionarios);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FuncionarioDtoRetorno>> Obter(Guid id)
    {
        var funcionario = await _funcionarioUseCase.ObterPorId(id);
        return CustomResponse(funcionario);
    }

    [HttpPost()]
    public async Task<ActionResult<FuncionarioDtoRetorno>> Adicionar(FuncionarioDto funcionarioDto)
    {
        var result = await _funcionarioUseCase.Adicionar(funcionarioDto);
        return CustomResponse(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<FuncionarioDtoRetorno>> Atualizar(Guid id, FuncionarioDto funcionarioDto)
    {
        funcionarioDto.Id = id;
        var result = await _funcionarioUseCase.Atualizar(funcionarioDto);
        return CustomResponse(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FuncionarioDtoRetorno>> Excluir(Guid id)
    {
        var result = await _funcionarioUseCase.Excluir(id);
        return CustomResponse(result);
    }
}