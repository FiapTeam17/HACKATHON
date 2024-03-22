using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HackatonFiap.Dominio.Ponto.Dtos
{
    public class RegistroPontoDto
    {
        [JsonIgnore]
        public DateTime Horario = DateTime.Now;
        public string? EmailFuncionario;
    }
}
