using System.Text.Json.Serialization;

namespace HackatonFiap.Dominio.Funcionario.Dtos;

public class FuncionarioDto
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}