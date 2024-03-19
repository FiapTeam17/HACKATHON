using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Dominio.Funcionario.Dtos;
using HackatonFiap.Dominio.Funcionario.Entities;
using HackatonFiap.Dominio.Funcionario.Models;

namespace HackatonFiap.Aplicacao.UserCases
{
    public class FuncionarioUseCase : IFuncionarioUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioUseCase(
            IFuncionarioRepository funcionarioRepository,
            IMapper mapper
            )
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioDto> Adicionar(FuncionarioDto funcionarioDto)
        {
            var funcionarioEntity = _mapper.Map<FuncionarioEntity>(funcionarioDto);
            //TODO validacaoes
            var funcionarioModel = _mapper.Map<FuncionarioModel>(funcionarioEntity);
            _funcionarioRepository.Adicionar(funcionarioModel);
            await _funcionarioRepository.SaveChanges().ConfigureAwait(false);
            return _mapper.Map<FuncionarioDto>(funcionarioModel);
        }

        public async Task<FuncionarioDto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FuncionarioDto>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<FuncionarioDto> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDto Atualizar(FuncionarioDto funcionarioDto)
        {
            throw new NotImplementedException();
        }
    }
}
