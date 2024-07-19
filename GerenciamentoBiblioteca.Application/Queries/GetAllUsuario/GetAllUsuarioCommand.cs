using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioCommand : IRequest<ResultViewModel<List<GetAllUsuarioViewModel>>>
    {
    }
}
