using Controle.Biblioteca.Domain;

namespace Controle.Biblioteca.Interface
{
    public interface IUsuarioService
    {
        void AdicionarUsuario(Usuario usuario);
        List<Usuario> ObterUsuarios();
    }
}
