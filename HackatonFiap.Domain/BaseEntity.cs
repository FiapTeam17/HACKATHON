using HackatonFiap.Comum.Notificacoes;

namespace HackatonFiap.Dominio;

    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public abstract bool Validacao(INotificador notificador);
    }

