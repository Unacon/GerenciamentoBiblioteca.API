using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.InativarUsuario
{
    public class InativarUsuarioCommand : IRequest<ResultViewModel>
    {
        public InativarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
