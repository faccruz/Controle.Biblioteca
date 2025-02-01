using Controle.Biblioteca.Domain;
using Controle.Biblioteca.Interface;
using Controle.Biblioteca.Service;

class Program
{
    static void Main()
    {
        var livroService = new LivroService();
        var usuarioService = new UsuarioService();
        var notificacaoService = usuarioService;
        var emprestimoService = new EmprestimoService(livroService, usuarioService, notificacaoService);

        while (true) 
        {
            Console.WriteLine("\nMenu Principal");
            Console.WriteLine("1. Adicionar usuário");
            Console.WriteLine("2. Adicionar Livro");
            Console.WriteLine("3. Listar livros disponíveis");
            Console.WriteLine("4. Emprestar Livro");
            Console.WriteLine("5. Devolver Livro");
            Console.WriteLine("6. Histórico do Livro");
            Console.WriteLine("7. Sair");
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
                    livroService.ListarLivrosDisponiveis();
                    break;
                case "4":
                    Console.WriteLine("ISBN do Livro: ");
                    string isbnEmprestimo = Console.ReadLine();
                    Console.WriteLine("ID do usuário: ");
                    int userId = int.Parse(Console.ReadLine());
                    emprestimoService.EmprestarLivro(isbnEmprestimo, userId);
                    break;
                case "5":
                    Console.WriteLine("ISBN do livro: ");
                    emprestimoService.DevolverLivro(Console.ReadLine());
                    break;
                case "6":
                    emprestimoService.MostrarHistorico();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}