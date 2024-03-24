using HackatonFiap.Dominio.Funcionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Models;
public record PeriodoModel : BaseModel
{
    public Guid RelatorioId { get; set; }
    public Guid FuncionarioId { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
}
