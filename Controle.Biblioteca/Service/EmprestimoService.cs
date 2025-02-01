using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly List<String> _historico = new();
        private readonly List<INotificationService> _notificationsService = new();
        private readonly ILivroService _livroService;
        private readonly IUsuarioService _usuarioService;

        public EmprestimoService(ILivroService livroService, IUsuarioService usuarioService)
        {
            _livroService = livroService;
            _usuarioService = usuarioService;
        }

        public void DevolverLivro(string isbn)
        {
            var livro = _livroService.ObterLivros().FirstOrDefault(l => l.ISBN == isbn && !l.Disponivel);
            if (livro != null) 
            {
                livro.Devolver();
            }
        }

        public void EmprestarLivro(string isbn, int idUsuario)
        {
            var livro = _livroService.ObterLivros().FirstOrDefault(l => l.ISBN == isbn && l.Disponivel);
            var usuario = _usuarioService.ObterUsuarios().FirstOrDefault(u => u.ID == idUsuario);

            if (livro != null && usuario != null)
            {
                livro.Emprestar();
                _historico.Add($"{usuario.Nome} empretou o livro '{livro.Titulo}'");                
            }
        }

        public void MostrarHistorico()
        {
            foreach (var item in _historico)            
            {
                Console.WriteLine(item);
            }
        }

        public void AdicionarObservador(INotificationService notificationService)
        {
            _notificationsService.Add(notificationService);
        }

        private void Notificacao(string msg) 
        {
            foreach(var item in _notificationsService)
            {
                item.Notificar(msg);
            }
        }
    }
}
