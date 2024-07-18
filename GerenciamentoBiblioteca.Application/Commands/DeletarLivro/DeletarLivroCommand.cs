using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarLivro
{
    public class DeletarLivroCommand : IRequest<Unit>
    {
        public DeletarLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
