using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Enums;
using HackatonFiap.Dominio.Ponto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Aplicacao.UserCases
{
    public class PontoUseCase : IPontoUseCase
    {
        private readonly IPontoRepository _pontoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly IFuncionarioUseCase _funcionarioUseCase;

        public PontoUseCase(
            IPontoRepository pontoRepository,
            IFuncionarioRepository funcionarioRepository,
            INotificador notificador,
            IMapper mapper,
            IFuncionarioUseCase funcionarioUseCase
            )
        {
            _pontoRepository = pontoRepository;
            _notificador = notificador;
            _mapper = mapper;
            _funcionarioUseCase = funcionarioUseCase;
            _funcionarioRepository = funcionarioRepository;
        }

        public Task<List<RegistroPontoDtoRetorno>> listarRegistrosFuncionario(string emailFuncionario)
        {
            throw new NotImplementedException();
        }

        public async Task<SolicitacaoRegistrosRetornoDto> ObterRegistrosDePontoDia(SolicitacaoRegistrosDiaDto solicitacaoRegistrosDiaDto)
        {
            var dia = DateTime.Parse(solicitacaoRegistrosDiaDto.data);
            var funcionario = await _funcionarioRepository.Obter(f => f.Email == solicitacaoRegistrosDiaDto.Email);
            var registros = await _pontoRepository.BuscarLista(r => r.FuncionarioId == funcionario.Id && r.Horario.Date == dia).ConfigureAwait(false);


            var retorno = new SolicitacaoRegistrosRetornoDto()
            {
                HorasTrabalhadas = CalcularHorasTrabalhadasDia(registros),
                Registros = PreencheRegistroDia(registros).OrderByDescending(r => r.Horario).ToList(),
            };

            return retorno;
        }

        public async Task RegistrarPonto(RegistroPontoDto registroPontoDto)
        {
            var funcionario = await _funcionarioRepository.Obter(f => f.Email == registroPontoDto.EmailFuncionario);
            var diaCorrente = DateTime.Today.Day;
            var registrosNoDia = await _pontoRepository.BuscarLista(r => r.FuncionarioId == funcionario.Id && r.Horario.Day == diaCorrente);
            var registroPonto = new PontoModel {
                Horario = registroPontoDto.Horario,
                FuncionarioId = funcionario.Id,
                tipo = VerificarTipoRegistro(registrosNoDia)
            };

            _pontoRepository.Adicionar(registroPonto);
            await _pontoRepository.SaveChanges();
        }

        private TipoRegistroPonto VerificarTipoRegistro(List<PontoModel> registros) {
            if (registros.Count() == 0) return TipoRegistroPonto.ENTRADA;
            return registros.Count() % 2 == 0 ? TipoRegistroPonto.ENTRADA : TipoRegistroPonto.SAIDA;
        }

        private string CalcularHorasTrabalhadasDia(List<PontoModel> registros)
        {
            TimeSpan horasTrabalhadas = TimeSpan.Zero;

            registros = registros.OrderByDescending(r => r.Horario).ToList();

            var entradas = registros.FindAll(r => r.tipo == TipoRegistroPonto.ENTRADA);
            var saidas = registros.FindAll(r => r.tipo == TipoRegistroPonto.SAIDA);

            if (entradas.Count() > saidas.Count())
            {
                // remover um registro da entrada e usar o removido para somar as horas até o fim do dia
                entradas.RemoveAt(entradas.Count() - 1);
            }

            for (int i = 0; i < saidas.Count(); i++)
            {
                horasTrabalhadas = horasTrabalhadas + ((DateTime)saidas[i].Horario - (DateTime)entradas[i].Horario);
            }
            var totalDia = Math.Round(horasTrabalhadas.TotalHours, 0);

            return horasTrabalhadas.ToString();
        }

        private List<ÌnformacoesRegistroPontoDto> PreencheRegistroDia(List<PontoModel> registros)
        {
            var retorno = new List<ÌnformacoesRegistroPontoDto>();

            foreach (PontoModel registro in registros)
            {
                retorno.Add(new ÌnformacoesRegistroPontoDto()
                {
                    Horario = registro.Horario,
                    TipoRegistro = registro.tipo
                });
            }

            return retorno;
        }
    }
}
