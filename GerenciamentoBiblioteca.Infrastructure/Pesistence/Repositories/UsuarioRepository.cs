using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public UsuarioRepository(GerenciamentoBibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(Usuario usuario)
        {
            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllUsuarioAsync()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetByIdUsuarioAsync(int id)
        {
            return await _dbContext.Usuario.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
