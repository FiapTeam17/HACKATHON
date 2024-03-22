using HackatonFiap.Dominio.Funcionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Models
{
    public record PontoModel : BaseModel
    {
        public DateTime Horario;
        public FuncionarioModel? Funcionario;
    }
}
