using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public CreateUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = new Usuario(request.Nome, request.Email);
            await _usuariorepository.CreateUsuarioAsync(usuario);

            return usuario.Id;
        }
    }
}
