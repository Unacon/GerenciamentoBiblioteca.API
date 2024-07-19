using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosHandler : IRequestHandler<GetAllLivrosQuery, ResultViewModel<List<GetAllLivrosViewModel>>>
    {
        private readonly ILivrosRepository _livrosRepository;

        public GetAllLivrosHandler(ILivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<ResultViewModel<List<GetAllLivrosViewModel>>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            List<Livro> livros = await _livrosRepository.GetAllAsync();

            if (livros.IsNullOrEmpty())
            {
                return ResultViewModel<List<GetAllLivrosViewModel>>.Error("Nenhum livro encontrado.");
            }

            List<GetAllLivrosViewModel> getAllLivrosViewModel = livros.Select(
               l => new GetAllLivrosViewModel(l.Id, l.Titulo, l.ISBN, l.AnoPublicacao)
                ).ToList();

            return ResultViewModel<List<GetAllLivrosViewModel>>.Sucess(getAllLivrosViewModel);


        }
    }
}
