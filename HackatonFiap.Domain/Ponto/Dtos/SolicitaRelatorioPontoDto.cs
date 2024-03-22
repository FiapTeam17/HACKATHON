namespace HackatonFiap.Dominio.Ponto.Dtos;
public class SolicitaRelatorioPontoDto
{
    public Guid FuncionarioId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public SolicitaRelatorioPontoStatusEnum Status { get; set; }
}
