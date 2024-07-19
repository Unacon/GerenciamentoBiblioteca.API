using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioCommand : IRequest<ResultViewModel<GetByIdUsuarioViewModel>>
    {
        public GetByIdUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
