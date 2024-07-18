namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Livro: BaseEntity
    {
        public Livro(string titulo, string emailAddress, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            EmailAddress = emailAddress;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Emprestimos = new List<Emprestimo>();
        }

        public string Titulo { get; private set; }
        public string EmailAddress { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }

    }
}
