using HackatonFiap.Dominio.Funcionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Entities
{
    public class PontoEntity
    {
        public DateTime horario { get; set; }
        public FuncionarioModel? funcionario { get; set; }
    }
}
