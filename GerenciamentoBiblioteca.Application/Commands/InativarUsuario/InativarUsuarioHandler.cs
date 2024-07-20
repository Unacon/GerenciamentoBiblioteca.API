using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.InativarUsuario
{
    public class InativarUsuarioHandler : IRequestHandler<InativarUsuarioCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public InativarUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<ResultViewModel> Handle(InativarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuariorepository.GetByIdUsuarioAsync(request.Id);

            if (usuario is null)
            {
                return ResultViewModel.Error("Usuáro não encontrado");
            }

            if (!usuario.Ativo)
            {
                return ResultViewModel.Error("Usuário já consta inativo");
            }

            usuario.InativarUsuario();
            await _usuariorepository.AtualizarUsuarioAsync(usuario);

            return ResultViewModel.Sucess();
        }
    }
}
