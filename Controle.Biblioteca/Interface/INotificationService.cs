namespace Controle.Biblioteca.Interface
{
    public interface INotificacaoObserver
    {
        void Notificar(string Mensagem);
    }

    public interface INotificacaoService
    {
        void NotificarObservadores(string Mensagem);
    }
}
