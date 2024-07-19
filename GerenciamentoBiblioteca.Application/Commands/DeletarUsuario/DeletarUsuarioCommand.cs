using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommand : IRequest<ResultViewModel>
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
