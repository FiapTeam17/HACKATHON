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

        public async Task RegistrarPonto(RegistroPontoDto registroPontoDto)
        {
            var funcionario = await _funcionarioRepository.Obter(f => f.Email == registroPontoDto.EmailFuncionario);
            var registroPonto = new PontoModel {
                Horario = registroPontoDto.Horario,
                Funcionario = funcionario
            };

            _pontoRepository.Adicionar(registroPonto);
        }
    }
}
