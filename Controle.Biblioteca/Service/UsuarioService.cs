using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly List<Usuario> usuarios = new();
        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public List<Usuario> ObterUsuarios() => usuarios;

    }
}
