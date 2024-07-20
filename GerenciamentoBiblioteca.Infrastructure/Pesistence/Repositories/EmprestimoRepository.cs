using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public EmprestimoRepository(GerenciamentoBibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarEmprestimo(Emprestimo emprestimo)
        {
            await _dbContext.Emprestimo.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarEmprestimo()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Emprestimo> GetByIdEmprestimo(int id)
        {
            return await _dbContext.Emprestimo.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
