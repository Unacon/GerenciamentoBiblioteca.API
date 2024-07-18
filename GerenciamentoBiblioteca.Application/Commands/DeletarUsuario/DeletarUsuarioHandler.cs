using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public DeletarUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuariorepository.GetByIdUsuarioAsync(request.Id);

            if(usuario is null)
            {
                return Unit.Value;
            }
            await _usuariorepository.DeletarUsuarioAsync(usuario);

            return Unit.Value;
        }
    }
}
