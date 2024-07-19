using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.CreateLivro
{
    public class CreateLivroHandler : IRequestHandler<CreateLivroCommand, ResultViewModel<int>>
    {
        private readonly ILivrosRepository _livrosRepository;

        public CreateLivroHandler(ILivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            Livro livro = new Livro(request.Titulo, request.EmailAddress, request.ISBN, request.AnoPublicacao);

            await _livrosRepository.CreateLivroAsync(livro);

            return ResultViewModel<int>.Sucess(livro.Id);
        }
    }
}
