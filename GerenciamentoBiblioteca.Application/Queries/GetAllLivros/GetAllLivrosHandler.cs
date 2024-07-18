using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosHandler : IRequestHandler<GetAllLivrosQuery, List<GetAllLivrosViewModel>>
    {
        private readonly ILivrosRepository _livrosRepository;

        public GetAllLivrosHandler(ILivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<List<GetAllLivrosViewModel>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            List<Livro> livros = await _livrosRepository.GetAllAsync();

            if (livros.IsNullOrEmpty())
            {
                return null;
            }

            List<GetAllLivrosViewModel> getAllLivrosViewModel = livros.Select(
               l => new GetAllLivrosViewModel(l.Id, l.Titulo, l.ISBN, l.AnoPublicacao)
                ).ToList();

            return getAllLivrosViewModel;


        }
    }
}
