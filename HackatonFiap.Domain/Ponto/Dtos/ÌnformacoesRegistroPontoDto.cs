using HackatonFiap.Dominio.Ponto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Dtos
{
    public class ÌnformacoesRegistroPontoDto
    {
        public DateTime? Horario {  get; set; }
        public TipoRegistroPonto TipoRegistro { get; set; }

    }

}
