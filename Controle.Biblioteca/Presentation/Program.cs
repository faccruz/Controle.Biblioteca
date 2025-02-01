using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Observer;
using Controle.Biblioteca.Service;

class Program
{
    static void Main()
    {
        var livroService = new LivroService();
        var usuarioService = new UsuarioService();
        var emprestimoService = new EmprestimoService(livroService, usuarioService);

        while (true) 
        {
            Console.WriteLine("\nMenu Principal");
            Console.WriteLine("1. Adicionar usuário");
            Console.WriteLine("2. Adicionar Livro");
            Console.WriteLine("3. Emprestar Livro");
            Console.WriteLine("4. Devolver Livro");
            Console.WriteLine("5. Histórico do Livro");
            Console.WriteLine("6. Sair");
            Console.WriteLine("Escolha uma opção: ");

            var opcao = Console.ReadLine();

            switch (opcao) 
            {
                case "1":
                    Console.WriteLine("Nome do usuário: ");
                    usuarioService.AdicionarUsuario(new Usuario(Console.ReadLine()));
                    break;
                case "2":
                    Console.WriteLine("Título do livro: ");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    string autor = Console.ReadLine();
                    Console.WriteLine("ISBN: ");
                    string isbn = Console.ReadLine();
                    livroService.AdicionarLivro(new Livro(titulo, autor, isbn));
                    break;
                case "3":
                    Console.WriteLine("ISBN do Livro: ");
                    string isbnEmprestimo = Console.ReadLine();
                    Console.WriteLine("ID do usuário: ");
                    int userId = int.Parse(Console.ReadLine());
                    emprestimoService.EmprestarLivro(isbnEmprestimo, userId);
                    break;
                case "4":
                    Console.WriteLine("ISBN do livro: ");
                    emprestimoService.DevolverLivro(Console.ReadLine());
                    break;
                case "5":
                    emprestimoService.MostrarHistorico();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}