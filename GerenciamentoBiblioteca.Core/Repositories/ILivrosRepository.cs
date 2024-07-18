using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Core.Repositories
{
    public interface ILivrosRepository
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro> GetByIdAsync(int id);
        Task CreateLivroAsync(Livro livro);
        Task DeletarLivro(Livro livro);
    }
}
