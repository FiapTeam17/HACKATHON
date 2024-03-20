using System.Linq.Expressions;
using HackatonFiap.Comum;
using Microsoft.EntityFrameworkCore.Storage;

namespace HackatonFiap.Aplicacao.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        Task<TEntity?> Obter(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<TEntity?> Obter(string ordenacao, Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<TEntity?> ObterTracking(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<TEntity?> ObterTracking(string ordenacao, Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<List<TEntity>> BuscarLista(Expression<Func<TEntity, bool>> expressao, params string[] includes);
        Task<List<TEntity>> BuscarLista(string ordenacao, Expression<Func<TEntity, bool>> expressao, params string[] includes);
        Task<List<TEntity>> BuscarLista(string filtro, string ordenacao = "id asc", params string[] includes);
        Task<List<TEntity>> BuscarListaTracking(Expression<Func<TEntity, bool>> expressao, params string[] includes);
        Task<List<TEntity>> BuscarListaTracking(string ordenacao, Expression<Func<TEntity, bool>> expressao, params string[] includes);
        Task<ListaPaginada<TEntity>> Buscar(Expression<Func<TEntity, bool>> expressao, string ordenacao = "id asc", int pagina = 1, int qtdeRegistros = 10, params string[] includes);
        Task<ListaPaginada<TEntity>> Buscar(string filtro, string ordenacao = "id asc", int pagina = 1, int qtdeRegistros = 10, params string[] includes);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        void Remover(List<TEntity> listaEntity);
        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> expressao);
        Task<int> Count(string filtro);
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
        IDbContextTransaction GetTransactionAsync();
        Task BeginTransactionAsync(Guid chaveTransacao, CancellationToken cancellationToken = default);
        Task CommitAsync(Guid chaveTransacao, CancellationToken cancellationToken = default);
        Task RollbackAsync(Guid chaveTransacao, CancellationToken cancellationToken = default);
        bool IsTracking(TEntity entity);
        void Track(TEntity entity);
        Task CarregarReferencias(TEntity entity);
        Task CarregarDetalhes(TEntity entity);
    }
}
