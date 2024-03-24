using HackatonFiap.Dominio.Ponto.Models;

namespace HackatonFiap.Dominio.Funcionario.Models;

public record FuncionarioModel : BaseModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? CognitoId { get; set; }

    public List<PontoModel>? Pontos { get; set; }
    public List<SolicitaRelatorioPontoModel>? SolicitaRelatorioPontos { get; set; }
}