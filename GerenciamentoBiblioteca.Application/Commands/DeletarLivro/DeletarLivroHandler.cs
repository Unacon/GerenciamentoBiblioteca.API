using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarLivro
{
    public class DeletarLivroHandler : IRequestHandler<DeletarLivroCommand, ResultViewModel>
    {
        private readonly ILivrosRepository _livrosRepository;

        public DeletarLivroHandler(ILivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<ResultViewModel> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            Livro livro = await _livrosRepository.GetByIdAsync(request.Id);

            if(livro is null)
            {
                return ResultViewModel.Error("Livro não encontrado");
            }

            await _livrosRepository.DeletarLivro(livro);

            return ResultViewModel.Sucess();
        }
    }
}
