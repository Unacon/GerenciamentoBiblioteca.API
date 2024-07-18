using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioHandler : IRequestHandler<GetByIdUsuarioCommand, GetByIdUsuarioViewModel>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public GetByIdUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<GetByIdUsuarioViewModel> Handle(GetByIdUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuariorepository.GetByIdUsuarioAsync(request.Id);

            if (usuario == null)
            {
                return null;
            }

            GetByIdUsuarioViewModel usuarioViewModel = new GetByIdUsuarioViewModel(usuario.Id, usuario.Nome, usuario.Email);

            return usuarioViewModel;
        }
    }
}
