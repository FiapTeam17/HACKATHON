using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Aplicacao.UserCases;
public class SolicitaRelatorioPontoUseCase : ISolicitaRelatorioPontoUseCase
{
    private readonly ISolicitaRelatorioPontoRepository _solicitaRelatorioPontoRepository;
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly INotificador _notificador;
    private readonly IMapper _mapper;
    private readonly IFuncionarioUseCase _funcionarioUseCase;
    private readonly ISqsRepository _sqsRepository;

    public SolicitaRelatorioPontoUseCase(
            INotificador notificador,
            IMapper mapper,
            ISolicitaRelatorioPontoRepository solicitaRelatorioPontoRepository,
            ISqsRepository sqsRepository
            )
    {
        _solicitaRelatorioPontoRepository = solicitaRelatorioPontoRepository;
        _notificador = notificador;
        _mapper = mapper;
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
