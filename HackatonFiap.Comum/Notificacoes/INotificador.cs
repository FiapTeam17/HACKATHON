namespace HackatonFiap.Comum.Notificacoes
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Notificar(Notificacao notificacao);
        void Notificar(string mensagem);
        public void Limpar();
    }
}
