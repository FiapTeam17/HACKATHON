using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Ponto.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HackatonFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : BaseController
    {
        private readonly IPontoUseCase _pontoUseCase;
        private readonly IUser _user;
        private readonly ILogger<PontoController> _logger;
        private readonly ISolicitaRelatorioPontoUseCase _solicitaRelatorioPontoUseCase;

        public PontoController(
            IPontoUseCase pontoUseCase,
            ISolicitaRelatorioPontoUseCase solicitaRelatorioPontoUseCase,
            IUser user,
            ILogger<PontoController> logger,
            INotificador notificador
        ) : base(notificador)
        {
            _pontoUseCase = pontoUseCase;
            _user = user;
            _logger = logger;
            _solicitaRelatorioPontoUseCase = solicitaRelatorioPontoUseCase;
        }

        [HttpPost()]
        public async Task<ActionResult> RegistrarPonto(RegistroPontoDto registroPontoDto)
        {
            await _pontoUseCase.RegistrarPonto(registroPontoDto);
            return Ok();
        }

        [HttpGet(("{id}"))]
        public async Task<ActionResult> GerarRelatorioDePonto(string email)
        {
            await _pontoUseCase.listarRegistrosFuncionario(email);
            return CustomResponse("OK");

        }

        [HttpPost("solicitarRelatorioPonto")]
        public async Task<ActionResult> SolicitarRelatorioPonto([FromBody]SolicitaRelatorioPontoDto solicitaRelatorioPontoDto)
        {
            await _solicitaRelatorioPontoUseCase.SolicitaRelatorioPonto(solicitaRelatorioPontoDto);
            return CustomResponse("OK");
        }
    }
}
