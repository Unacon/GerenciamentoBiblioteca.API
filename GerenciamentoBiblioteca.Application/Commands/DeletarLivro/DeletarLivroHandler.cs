using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarLivro
{
    public class DeletarLivroHandler : IRequestHandler<DeletarLivroCommand, Unit>
    {
        private readonly ILivrosRepository _livrosRepository;

        public DeletarLivroHandler(ILivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<Unit> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            Livro livro = await _livrosRepository.GetByIdAsync(request.Id);

            await _livrosRepository.DeletarLivro(livro);

            return Unit.Value;
        }
    }
}
