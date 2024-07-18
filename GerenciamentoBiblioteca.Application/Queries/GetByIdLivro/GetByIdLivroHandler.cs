using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdLivros
{
    internal class GetByIdLivroHandler : IRequestHandler<GetByIdLivroQuery, GetByIdLivroViewModel>
    {
        private readonly ILivrosRepository _livrosRepository;

        public GetByIdLivroHandler(ILivrosRepository LivroRepository)
        {
            _livrosRepository = LivroRepository;
        }

        public async Task<GetByIdLivroViewModel> Handle(GetByIdLivroQuery request, CancellationToken cancellationToken)
        {
            Livro livro = await _livrosRepository.GetByIdAsync(request.Id);

            if(livro == null)
            {
                return null;
            }

            GetByIdLivroViewModel getByIdLivroViewModel = new GetByIdLivroViewModel(livro.Id, livro.Titulo, livro.EmailAddress, livro.ISBN, livro.AnoPublicacao);

            return getByIdLivroViewModel;
        }
    }
}
