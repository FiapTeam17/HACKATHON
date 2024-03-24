using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Models;

namespace HackatonFiap.Aplicacao.UserCases;
public class SolicitaRelatorioPontoUseCase : ISolicitaRelatorioPontoUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly ISolicitaRelatorioPontoRepository _solicitaRelatorioPontoRepository;
    private readonly INotificador _notificador;
    private readonly IUser _user;
    private readonly ISqsRepository _sqsRepository;

    public SolicitaRelatorioPontoUseCase(
        IFuncionarioRepository funcionarioRepository,
        ISolicitaRelatorioPontoRepository solicitaRelatorioPontoRepository,
        INotificador notificador,
        IUser user,
        ISqsRepository sqsRepository
    )
    {
        _funcionarioRepository = funcionarioRepository;
        _solicitaRelatorioPontoRepository = solicitaRelatorioPontoRepository;
        _notificador = notificador;
        _user = user;

        _sqsRepository = sqsRepository;
    }

    public async Task SolicitaRelatorioPonto(SolicitaRelatorioPontoDto solicitaRelatorioPontoDto)
    {
        var funcionarioModel = await _funcionarioRepository.Obter(f => f.Email == _user.GetUserEmail());
        if (funcionarioModel == null)
        {
            _notificador.Notificar("Funcionário não localizado");
            return;
        }
        
        var solicitaPonto = new SolicitaRelatorioPontoModel
        {
            DataFim = solicitaRelatorioPontoDto.DataFim,
            DataInicio = solicitaRelatorioPontoDto.DataInicio,
            FuncionarioId = funcionarioModel.Id,
            Status = "PENDENTE"
        };

        _solicitaRelatorioPontoRepository.Adicionar(solicitaPonto);
        await _solicitaRelatorioPontoRepository.SaveChanges();
        await _sqsRepository.SolicitarRelatorio(new PeriodoModel
        {
            Ano = solicitaPonto.DataInicio.Year,
            Mes = solicitaPonto.DataInicio.Month,
            FuncionarioId = solicitaPonto.FuncionarioId,
            RelatorioId = solicitaPonto.Id
        });
    }
}