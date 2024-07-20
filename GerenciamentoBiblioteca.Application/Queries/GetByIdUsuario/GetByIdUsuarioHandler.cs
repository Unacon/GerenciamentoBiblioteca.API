using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioHandler : IRequestHandler<GetByIdUsuarioCommand, ResultViewModel<GetByIdUsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public GetByIdUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<ResultViewModel<GetByIdUsuarioViewModel>> Handle(GetByIdUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuariorepository.GetByIdUsuarioAsync(request.Id);

            if (usuario is null)
            {
                return ResultViewModel<GetByIdUsuarioViewModel>.Error("Usuário não encontrado");
            }

            GetByIdUsuarioViewModel usuarioViewModel = new GetByIdUsuarioViewModel(usuario.Id, usuario.Nome, usuario.Email, usuario.Ativo);

            return ResultViewModel<GetByIdUsuarioViewModel>.Sucess(usuarioViewModel);
        }
    }
}
