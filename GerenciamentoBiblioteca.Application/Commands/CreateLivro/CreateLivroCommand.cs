using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.CreateLivro
{
    public class CreateLivroCommand : IRequest<int>
    {
        public CreateLivroCommand(string titulo, string emailAddress, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            EmailAddress = emailAddress;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public string Titulo { get; private set; }
        public string EmailAddress { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
    }
}
