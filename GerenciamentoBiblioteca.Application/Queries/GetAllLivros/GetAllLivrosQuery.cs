using GerenciamentoBiblioteca.Core.Entities;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<List<GetAllLivrosViewModel>>
    {
    }
}
