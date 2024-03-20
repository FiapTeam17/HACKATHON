using HackatonFiap.Comum.Notificacoes;

namespace HackatonFiap.Dominio.Funcionario.Entities;

public class FuncionarioEntity : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public override bool Validacao(INotificador notificador)
    {
        var res = true;
        if (string.IsNullOrEmpty(Nome))
        {
            notificador.Notificar("Nome é obrigatório!");
            res = false;
        }
        
        if (string.IsNullOrEmpty(Email))
        {
            notificador.Notificar("E-mail é obrigatório!");
            res = false;
        }

        return res;
    }
}