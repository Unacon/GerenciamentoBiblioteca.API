using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioCommand, List<GetAllUsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public GetAllUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<List<GetAllUsuarioViewModel>> Handle(GetAllUsuarioCommand request, CancellationToken cancellationToken)
        {
            List<Usuario> usuarios = await _usuariorepository.GetAllUsuarioAsync();

            if (usuarios.IsNullOrEmpty())
            {
                return null;
            }

            List<GetAllUsuarioViewModel> usuariosViewModel = usuarios.Select(u => new GetAllUsuarioViewModel(u.Id, u.Nome, u.Email)).ToList();

            return usuariosViewModel;
        }
    }
}
