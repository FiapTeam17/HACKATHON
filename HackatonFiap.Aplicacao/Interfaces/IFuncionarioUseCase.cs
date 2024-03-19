using HackatonFiap.Dominio.Funcionario.Dtos;

namespace HackatonFiap.Aplicacao.Interfaces
{
    public interface IFuncionarioUseCase
    {
        Task<FuncionarioDto> Adicionar(FuncionarioDto funcionarioDto);
        Task<FuncionarioDto> ObterPorId(Guid id);
        Task<List<FuncionarioDto>> ObterTodos();
        Task<FuncionarioDto> Excluir(Guid id);
        FuncionarioDto Atualizar(FuncionarioDto funcionarioDto);
    }
}
