using GerenciamentoBiblioteca.Core.Entities;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioCommand : IRequest<List<GetAllUsuarioViewModel>>
    {
    }
}
