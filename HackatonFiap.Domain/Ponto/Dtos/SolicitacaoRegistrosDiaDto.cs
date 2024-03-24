using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Dtos
{
    public class SolicitacaoRegistrosDiaDto
    {
        required public string Email { get; set; }

        required public string data { get; set; }
    }
}
