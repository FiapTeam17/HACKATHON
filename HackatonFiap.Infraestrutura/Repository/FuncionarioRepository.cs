using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Dominio.Model;
using HackatonFiap.Infraestrutura.Context;

namespace HackatonFiap.Infraestrutura.Repository;

public class FuncionarioRepository : BaseRepository<FuncionarioModel>, IFuncionarioRepository
{
    public FuncionarioRepository(
        DatabaseContext dbContext,
        ITransactionService transactionService
    ) : base(dbContext, transactionService)
    {
    }
}