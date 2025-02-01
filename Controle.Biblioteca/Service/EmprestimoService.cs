using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly List<String> _historico = new();
        private readonly INotificacaoService _notificacaoService;
        private readonly ILivroService _livroService;
        private readonly IUsuarioService _usuarioService;

        public EmprestimoService(ILivroService livroService, IUsuarioService usuarioService, INotificacaoService notificacaoService )
        {
            _livroService = livroService;
            _usuarioService = usuarioService;
            _notificacaoService = notificacaoService;
        }

        public void DevolverLivro(string isbn)
        {
            var livro = _livroService.ObterLivros().FirstOrDefault(l => l.ISBN == isbn && !l.Disponivel);
            if (livro != null) 
            {
                livro.Devolver();
                _notificacaoService.NotificarObservadores($"Livro '{livro.Titulo}' foi devolvido.");
            }
        }

        public void EmprestarLivro(string isbn, int idUsuario)
        {
            var livro = _livroService.ObterLivros().FirstOrDefault(l => l.ISBN == isbn && l.Disponivel);
            var usuario = _usuarioService.ObterUsuarios().FirstOrDefault(u => u.ID == idUsuario);

            if (livro != null && usuario != null)
            {
                livro.Emprestar();
                _historico.Add($"{DateTime.Now}: {usuario.Nome} empretou o livro '{livro.Titulo}'");
                _notificacaoService.NotificarObservadores($"{usuario.Nome} emprestou '{livro.Titulo}'");
            }
        }

        public void MostrarHistorico()
        {
            foreach (var item in _historico)            
            {
                Console.WriteLine(item);
            }
        }
    }
}
