using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> GetByIdEmprestimo(int id);

        Task AtualizarEmprestimo();

        Task CadastrarEmprestimo(Emprestimo emprestimo);
    }
}
