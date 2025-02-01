namespace Controle.Biblioteca.Interface
{
    public interface IEmprestimoService
    {
        void EmprestarLivro(string isbn, int idUsuario);
        void DevolverLivro(string isbn);
        void MostrarHistorico();
    }
}
