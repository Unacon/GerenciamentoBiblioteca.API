namespace GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioViewModel
    {
        public GetByIdUsuarioViewModel(int id, string nome, string email, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
    }
}
