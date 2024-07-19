using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public DeletarUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<ResultViewModel> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuariorepository.GetByIdUsuarioAsync(request.Id);

            if (usuario is null)
            {
                return ResultViewModel.Error("Usuáro não encontrado");
            }

            await _usuariorepository.DeletarUsuarioAsync(usuario);

            return ResultViewModel.Sucess();
        }
    }
}
