using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DevolverEmprestimo
{
    public class DevolverEmprestimoHandler : IRequestHandler<DevolverEmprestimoCommand, ResultViewModel>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public DevolverEmprestimoHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<ResultViewModel> Handle(DevolverEmprestimoCommand request, CancellationToken cancellationToken)
        {
            Emprestimo emprestimo = await _emprestimoRepository.GetByIdEmprestimo(request.Id);

            if (emprestimo is null)
            {
                return ResultViewModel.Error("Empréstimo não encontrado.");
            }

            if (emprestimo.DataDevolucao is not null)
            {
                return ResultViewModel.Error("Empréstimo já foi devolvido.");
            }

            emprestimo.Devolucao();
            await _emprestimoRepository.AtualizarEmprestimo();

            if (emprestimo.DataPrevistaDaDevolucao > DateTime.Now)
            {
                TimeSpan diasAtrasado = emprestimo.DataPrevistaDaDevolucao.Subtract(DateTime.Now);
                return ResultViewModel.Sucess("Devolução feita com " + diasAtrasado + " de atraso");
            }
            else
            {
                return ResultViewModel.Sucess("Devolução em dia.");
            }
        }
    }
}
