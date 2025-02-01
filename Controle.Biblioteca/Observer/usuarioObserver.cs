using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Observer
{
    public class usuarioObserver : INotificationService
    {
        private readonly string _nome;
        
        public usuarioObserver(string nome) {  _nome = nome; }
        
        public void Notificar(string Mensagem)
        {
            Console.WriteLine($"Notificação para {_nome}: {Mensagem}");
        }
    }
}
