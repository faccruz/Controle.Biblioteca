using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Service
{
    public class UsuarioService : IUsuarioService, INotificacaoService
    {
        private readonly List<Usuario> usuarios = new();
        private readonly List<INotificacaoObserver> _observadores = new();

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            _observadores.Add(usuario);
        }

        public List<Usuario> ObterUsuarios() => usuarios;

        public void NotificarObservadores(string mensagem)
        {
            foreach (var usuario in _observadores)
            {
                usuario.Notificar(mensagem);
            }
        }

    }
}
