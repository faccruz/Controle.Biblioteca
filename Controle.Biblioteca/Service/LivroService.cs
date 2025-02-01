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

        public void ListarLivrosDisponiveis()
        {
            var disponivel = _livros.Where(l => l.Disponivel).ToList();

            if (disponivel.Count == 0)
            {
                Console.WriteLine("Nenhum livro disponível para empréstimo.");
            }
            else
            {
                Console.WriteLine("Livros disponiveis:");
                foreach (var item in disponivel)
                {
                    Console.WriteLine($"{item.Titulo} - {item.Autor} - {item.ISBN}");
                }
            }
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
