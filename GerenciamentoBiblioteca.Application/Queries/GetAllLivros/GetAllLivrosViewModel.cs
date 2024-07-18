namespace GerenciamentoBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosViewModel
    {
        public GetAllLivrosViewModel(int id,string titulo, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
    }
}
