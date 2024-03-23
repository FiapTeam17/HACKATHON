using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Dominio.Ponto.Models;
using HackatonFiap.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Infraestrutura.Repository;
public class SolicitaRelatorioPontoRepository : BaseRepository<SolicitaRelatorioPontoModel>, ISolicitaRelatorioPontoRepository
{
    public SolicitaRelatorioPontoRepository(DatabaseContext dbContext,
    ITransactionService transactionService) : base(dbContext, transactionService)
    { }
}
