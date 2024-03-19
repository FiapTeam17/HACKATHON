using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Dominio.Funcionario.Dtos;

namespace HackatonFiap.Aplicacao.UserCases
{
    public class FuncionarioUseCase : IFuncionarioUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioUseCase(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public FuncionarioDto Adicionar(FuncionarioDto funcionarioDto)
        {
            throw new NotImplementedException();
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
