using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
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
    private readonly IPontoRepository _pontoRepository;
    private readonly ISolicitaRelatorioPontoRepository _solicitaRelatorioPontoRepository;
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly INotificador _notificador;
    private readonly IMapper _mapper;
    private readonly IFuncionarioUseCase _funcionarioUseCase;
    private readonly ISolicitaRelatorioPontoUseCase _solicitaRelatorioPontoUseCase;

    public SolicitaRelatorioPontoUseCase(
            IPontoRepository pontoRepository,
            IFuncionarioRepository funcionarioRepository,
            INotificador notificador,
            IMapper mapper,
            IFuncionarioUseCase funcionarioUseCase,
            ISolicitaRelatorioPontoUseCase solicitaRelatorioPontoUseCase,
            ISolicitaRelatorioPontoRepository solicitaRelatorioPontoRepository
            )
    {
        _pontoRepository = pontoRepository;
        _solicitaRelatorioPontoRepository = solicitaRelatorioPontoRepository;
        _notificador = notificador;
        _mapper = mapper;
        _funcionarioUseCase = funcionarioUseCase;
        _funcionarioRepository = funcionarioRepository;
        _solicitaRelatorioPontoUseCase = solicitaRelatorioPontoUseCase;
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
    }
}
