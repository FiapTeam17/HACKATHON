namespace HackatonFiap.Dominio.Model;

public record FuncionarioModel : BaseModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
}