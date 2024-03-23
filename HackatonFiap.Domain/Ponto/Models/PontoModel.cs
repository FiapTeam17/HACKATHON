using HackatonFiap.Dominio.Funcionario.Models;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Models
{
    public record PontoModel : BaseModel
    {
        public DateTime Horario { get; set; }
        public FuncionarioModel? Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
        public TipoRegistroPonto tipo {  get; set; }
    }
}
