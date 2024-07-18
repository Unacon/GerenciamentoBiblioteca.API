namespace GerenciamentoBiblioteca.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioViewModel
    {
        public GetAllUsuarioViewModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
