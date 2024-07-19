namespace GerenciamentoBiblioteca.Application.Commands.CreateUsuario
{
    public class CreateUsuarioViewModel
    {
        public CreateUsuarioViewModel(int id, string nome, string email)
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
