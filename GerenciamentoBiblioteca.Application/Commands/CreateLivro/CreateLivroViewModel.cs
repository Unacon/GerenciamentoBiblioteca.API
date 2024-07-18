namespace GerenciamentoBiblioteca.Application.Commands.CreateLivro
{
    public class CreateLivroViewModel
    {
        public CreateLivroViewModel(int id, string titulo, string emailAddress, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            EmailAddress = emailAddress;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string EmailAddress { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
    }
}
