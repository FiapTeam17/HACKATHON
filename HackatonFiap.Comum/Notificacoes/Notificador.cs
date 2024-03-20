namespace HackatonFiap.Comum.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Notificar(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void Notificar(string mensagem)
        {
            _notificacoes.Add(new Notificacao(mensagem));
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public void Limpar()
        {
            _notificacoes = new();
        }

    }
}
