using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories
{
    public class LivrosRepository : ILivrosRepository
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public LivrosRepository(GerenciamentoBibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLivroAsync(Livro livro)
        {
            await _dbContext.Livro.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            return await _dbContext.Livro.ToListAsync();
        }

        public async Task<Livro> GetByIdAsync(int id)
        {
            return await _dbContext.Livro
                .SingleOrDefaultAsync(l => l.Id == id);
        }
        public async Task DeletarLivro(Livro livro)
        {
            _dbContext.Livro.Remove(livro);
            await _dbContext.SaveChangesAsync();
        }

    }
}
