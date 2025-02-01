namespace Controle.Biblioteca.Domain
{
    public class Usuario
    {
        public string Nome { get; }
        public int ID { get; }
        private static int contador = 1;

        public Usuario(string nome)
        {
            Nome = nome;
            ID = contador++;
        }
    }
}
