namespace HackatonFiap.Dominio.Funcionario.Models;

public record FuncionarioModel : BaseModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
}