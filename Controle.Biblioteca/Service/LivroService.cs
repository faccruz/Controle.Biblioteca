using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Service
{
    public class LivroService : ILivroService
    {
        public readonly List<Livro> _livros = new();

        public void AdicionarLivro(Livro livro)
        {
            _livros.Add(livro);
        }

        public void ListarLivroDisponivel()
        {
            foreach (var item in _livros.Where(x => x.Disponivel) )
            {
                Console.WriteLine($"{item.Titulo} - {item.Autor} - {item.ISBN}");
            }
        }

        public List<Livro> ObterLivros() => _livros;

    }
}
