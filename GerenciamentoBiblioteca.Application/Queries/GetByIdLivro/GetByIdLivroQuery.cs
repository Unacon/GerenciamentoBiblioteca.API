using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdLivros
{
    public class GetByIdLivroQuery : IRequest<ResultViewModel<GetByIdLivroViewModel>>
    {
        public GetByIdLivroQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
