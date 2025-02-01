using Controle.Biblioteca.Domain;

namespace Controle.Biblioteca.Interface
{
    public interface ILivroService
    {
        void AdicionarLivro(Livro livro);
        void ListarLivroDisponivel();
        List<Livro> ObterLivros();
    }
}
