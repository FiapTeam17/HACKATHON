using HackatonFiap.Dominio.Funcionario.Models;

namespace HackatonFiap.Dominio.Ponto.Models
{
    public record PontoModel : BaseModel
    {
        public DateTime Horario { get; set; }
        public FuncionarioModel? Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
