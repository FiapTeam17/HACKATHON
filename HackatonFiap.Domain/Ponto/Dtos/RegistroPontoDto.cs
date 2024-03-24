using System.Text.Json.Serialization;

namespace HackatonFiap.Dominio.Ponto.Dtos
{
    public class RegistroPontoDto
    {
        [JsonIgnore]
        public DateTime Horario { get; set; } = DateTime.Now;
        public string? EmailFuncionario { get; set; }
}
}
