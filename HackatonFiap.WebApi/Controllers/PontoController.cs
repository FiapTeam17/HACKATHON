using HackatonFiap.Dominio.Funcionario.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;

namespace HackatonFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : BaseController
    {
        private readonly IPontoUseCase _pontoUseCase;
        private readonly ILogger<PontoController> _logger;

        public PontoController(
            IPontoUseCase funcionarioUseCase,
            ILogger<PontoController> logger,
            INotificador notificador,
            IUser appUser
        ) : base(notificador, appUser)
        {
            _pontoUseCase = funcionarioUseCase;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<ActionResult> RegistrarPonto(RegistroPontoDto registroPontoDto)
        {
            await _pontoUseCase.RegistrarPonto(registroPontoDto);
            return CustomResponse("OK");
        }

        [HttpGet(("{id}"))]
        public async Task<ActionResult> GerarRelatorioDePonto(string email)
        {
            await _pontoUseCase.listarRegistrosFuncionario(email);
            return CustomResponse("OK");
        }
    }
}
