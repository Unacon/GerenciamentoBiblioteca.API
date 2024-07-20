using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.ReativarUsuario
{
    public class ReativarUsuarioCommand : IRequest<ResultViewModel>
    {
        public ReativarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
