using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdEmprestimo
{
    public class GetByIdEmprestimoCommand : IRequest<ResultViewModel<Emprestimo>>
    {
        public GetByIdEmprestimoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
