using HackatonFiap.Dominio.Ponto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Dtos
{
    public class SolicitacaoRegistrosRetornoDto
    {
        public List<ÌnformacoesRegistroPontoDto> Registros { get; set; }
        public string HorasTrabalhadas { get; set; }

    }
}
