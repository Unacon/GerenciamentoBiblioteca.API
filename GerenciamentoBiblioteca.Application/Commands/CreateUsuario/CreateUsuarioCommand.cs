using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<ResultViewModel<int>>
    {
        public CreateUsuarioCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
