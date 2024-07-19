using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<ResultViewModel<List<GetAllLivrosViewModel>>>
    {
    }
}
