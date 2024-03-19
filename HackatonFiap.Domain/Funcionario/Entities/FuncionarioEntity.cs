namespace HackatonFiap.Dominio.Funcionario.Entities;

public record FuncionarioEntity : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }
}