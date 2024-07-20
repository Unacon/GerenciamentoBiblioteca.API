using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuarioAsync();

        Task<Usuario> GetByIdUsuarioAsync(int id);

        Task AtualizarUsuarioAsync(Usuario usuario);

        Task CreateUsuarioAsync(Usuario usuario);
    }
}
