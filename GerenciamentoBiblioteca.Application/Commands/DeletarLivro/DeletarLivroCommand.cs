using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarLivro
{
    public class DeletarLivroCommand : IRequest<ResultViewModel>
    {
        public DeletarLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
