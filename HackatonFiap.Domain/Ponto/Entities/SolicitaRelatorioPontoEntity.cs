using HackatonFiap.Dominio.Ponto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Entities;
public class SolicitaRelatorioPontoEntity
{
    public Guid FuncionarioId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public SolicitaRelatorioPontoStatusEnum Status { get; set; }
}
