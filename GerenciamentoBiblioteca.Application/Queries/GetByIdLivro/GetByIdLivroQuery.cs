using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdLivros
{
    public class GetByIdLivroQuery : IRequest<GetByIdLivroViewModel>
    {
        public GetByIdLivroQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
