using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum;
using HackatonFiap.Dominio.Funcionario.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HackatonFiap.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioUseCase _funcionarioUseCase;
    private readonly ILogger<FuncionarioController> _logger;

    public FuncionarioController(
        IFuncionarioUseCase funcionarioUseCase,
        ILogger<FuncionarioController> logger
    )
    {
        _funcionarioUseCase = funcionarioUseCase;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FuncionarioDto>> Obter(Guid id)
    {
        return Ok();
    }

    [HttpGet()]
    public async Task<ActionResult<ListaPaginada<FuncionarioDto>>> ObterTodos(
        [FromQuery] string filtro = "", 
        [FromQuery] bool ativo = true, [FromQuery] string ordenacao = "id asc", 
        [FromQuery] int pagina = 1, [FromQuery] int qtdeRegistros = 10)
    {
        return Ok();
    }

    [HttpPost()]
    public async Task<ActionResult<FuncionarioDto>> Adicionar(FuncionarioDto command)
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<FuncionarioDto>> Atualizar(Guid id, FuncionarioDto command)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FuncionarioDto>> Excluir(Guid id)
    {
        return Ok();
    }
}