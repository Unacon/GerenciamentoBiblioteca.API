using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.ReativarUsuario
{
    public class ReativarUsuarioHandler : IRequestHandler<ReativarUsuarioCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ReativarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel> Handle(ReativarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuarioRepository.GetByIdUsuarioAsync(request.Id);

            if(usuario is null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }

            if (usuario.Ativo)
            {
                return ResultViewModel.Error("Usuário já consta ativo.");
            }

            usuario.AtivarUsuario();
            await _usuarioRepository.AtualizarUsuarioAsync(usuario);

            return ResultViewModel.Sucess();
        }
    }
}
