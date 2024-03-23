using HackatonFiap.Dominio.Funcionario.Models;
using HackatonFiap.Dominio.Ponto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Models;
public record SolicitaRelatorioPontoModel : BaseModel
{
    public Guid FuncionarioId { get; set; }
    public FuncionarioModel? Funcionario { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Status { get; set; }
    public string? CaminhoArquivo { get; set; }
}
