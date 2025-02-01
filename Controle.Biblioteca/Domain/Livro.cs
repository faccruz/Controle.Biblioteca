namespace Controle.Biblioteca.Domain
{
    public class Livro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public string ISBN { get; }
        public bool Disponivel { get; private set; } = true;

        public Livro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
        }

        public void Emprestar() => Disponivel = false;
        public void Devolver() => Disponivel = true;
    }
}
