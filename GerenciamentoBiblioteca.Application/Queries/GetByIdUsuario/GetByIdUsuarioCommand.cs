using GerenciamentoBiblioteca.Core.Entities;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioCommand : IRequest<GetByIdUsuarioViewModel>
    {
        public GetByIdUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
