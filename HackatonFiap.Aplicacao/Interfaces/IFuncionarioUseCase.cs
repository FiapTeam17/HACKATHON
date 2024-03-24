using HackatonFiap.Comum;
using HackatonFiap.Dominio.Funcionario.Dtos;

namespace HackatonFiap.Aplicacao.Interfaces
{
    public interface IFuncionarioUseCase
    {
        Task<FuncionarioDtoRetorno?> Adicionar(FuncionarioDto funcionarioDto);
        Task<FuncionarioDtoRetorno> ObterPorId(Guid id);
        Task<ListaPaginada<FuncionarioDtoRetorno>> Listar(string filtro = "", string ordenacao = "id asc", 
            int pagina = 1, int qtdeRegistros = 10);
        Task<FuncionarioDtoRetorno?> Excluir(Guid id);
        Task<FuncionarioDtoRetorno?> Atualizar(FuncionarioDto funcionario);
    }
}
