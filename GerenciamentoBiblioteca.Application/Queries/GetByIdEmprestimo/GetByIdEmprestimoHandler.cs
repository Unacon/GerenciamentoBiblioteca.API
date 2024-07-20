using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdEmprestimo
{
    public class GetByIdEmprestimoHandler : IRequestHandler<GetByIdEmprestimoCommand, ResultViewModel<Emprestimo>>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public GetByIdEmprestimoHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<ResultViewModel<Emprestimo>> Handle(GetByIdEmprestimoCommand request, CancellationToken cancellationToken)
        {
            Emprestimo emprestimo = await _emprestimoRepository.GetByIdEmprestimo(request.Id);

            if(emprestimo is null)
            {
                return ResultViewModel<Emprestimo>.Error("Empréstimo não encontrado.");
            }

            return ResultViewModel<Emprestimo>.Sucess(emprestimo);
        }
    }
}
