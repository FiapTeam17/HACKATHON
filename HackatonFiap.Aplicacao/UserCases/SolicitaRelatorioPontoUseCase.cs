using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Models;

namespace HackatonFiap.Aplicacao.UserCases;
public class SolicitaRelatorioPontoUseCase : ISolicitaRelatorioPontoUseCase
{
    private readonly ISolicitaRelatorioPontoRepository _solicitaRelatorioPontoRepository;
    private readonly ISqsRepository _sqsRepository;

    public SolicitaRelatorioPontoUseCase(
            ISolicitaRelatorioPontoRepository solicitaRelatorioPontoRepository,
            ISqsRepository sqsRepository
            )
    {
        _solicitaRelatorioPontoRepository = solicitaRelatorioPontoRepository;
        
        _sqsRepository = sqsRepository;
    }

    public async Task SolicitaRelatorioPonto(SolicitaRelatorioPontoDto solicitaRelatorioPontoDto)
    {
        var solicitaPonto = new SolicitaRelatorioPontoModel
        {
            DataFim = solicitaRelatorioPontoDto.DataFim,
            DataInicio = solicitaRelatorioPontoDto.DataInicio,
            FuncionarioId = solicitaRelatorioPontoDto.FuncionarioId,
            Status = solicitaRelatorioPontoDto.Status,
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
